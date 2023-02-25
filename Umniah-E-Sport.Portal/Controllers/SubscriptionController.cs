using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Portal.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Umniah_E_Sport.Portal.ActionFilter;
using System;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Umniah_E_Sport.Portal.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        public static string keyAES = "SupportZAAAIN@Smartlink@2022-DG-";
        public SubscriptionController(IConfiguration config)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendPinCode(string PhoneNumber, bool IsUnSub = false)
        {
            if (IsUnSub == true)
            {
                if (string.IsNullOrEmpty(PhoneNumber))
                {
                    ViewBag.WrongMessage = "Invalid Phone number";
                    return View("Index");
                }

                var msisdnCookie = HttpContext.Request.Cookies["MSISDN"];
                if (!string.IsNullOrEmpty(msisdnCookie) && msisdnCookie != PhoneNumber)
                {
                    ViewBag.WrongMessage = "Invalid phone number";
                    return View("Index");
                }
            }

            var GenerateOTPresponse = await _swaggerClient.GetOtpAsync(new GenerateOTPQuery { Msisdn = PhoneNumber });
            if (GenerateOTPresponse.Success)
            {
                HttpContext.Response.Cookies.Append("MSISDN", PhoneNumber, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1)
                });
                return View("Verify");
            }
            else if (GenerateOTPresponse.Success == false && GenerateOTPresponse.Message == "User Already Exist.")
            {
                string otp = RandomOTP(4);
                string smsContent = $"Umniah-E-Sports OTP: {otp}";

                if (!IsUnSub)
                {
                    HttpContext.Response.Cookies.Append("PhoneNumber", PhoneNumber, new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddYears(1)
                    });
                }

                HttpContext.Response.Cookies.Append("OTP", EncryptString(otp), new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTime.Now.AddHours(2)
                });

                await _swaggerClient.SendSmsContentAsync(PhoneNumber, smsContent);
                ViewBag.IsUnSub = IsUnSub;
                return View("Verify");
            }
            else
            {
                ViewBag.WrongMessage = "Wrong Number";
                return View("Index");
            }
        }

        //[HttpGet("Verify")]
        public IActionResult Verify(bool wrongPin = false)
        {
            ViewBag.wrongPin = wrongPin;
            return View();
        }

        [HttpPost("Verify")]
        public async Task<IActionResult> Verify(string PinCode, bool IsUnSub = false)
        {
            string msisdnCookie = HttpContext.Request.Cookies["MSISDN"];
            string emailCookie = HttpContext.Request.Cookies["EMAIL"];
            string otpCookie = HttpContext.Request.Cookies["OTP"];
            if (!string.IsNullOrEmpty(PinCode) && otpCookie == null && IsUnSub == false)
            {
                var response = await _swaggerClient.SubscribeUserAsync(new ValidateOTPQuery { Msisdn = msisdnCookie, Otp = PinCode, Email = emailCookie });
                if (response.Success)
                {
                    // await _swaggerClient.SendSmsAsync(msisdnCookie, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //ViewBag.WrongMessage = "Please enter the right code";
                    ViewBag.WrongMessage = response.Message; // temp. solution till the testing phase
                    return View("Verify");
                }
            }
            else if (otpCookie != null && IsUnSub == false)
            {
                //VERIFY
                if (DecryptString(otpCookie) == PinCode)
                {
                    HttpContext.Response.Cookies.Delete("OTP");
                    var phoneNumber = HttpContext.Request.Cookies["PhoneNumber"];
                    HttpContext.Response.Cookies.Delete("PhoneNumber");
                    HttpContext.Response.Cookies.Append("MSISDN", phoneNumber, new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddYears(1)
                    });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.WrongMessage = "Invalid pin code.";
                    return View("Verify");
                }
            }
            else if (IsUnSub)
            {
                if (DecryptString(otpCookie) == PinCode)
                {
                    return RedirectToAction("UnSubUserFromDb");
                }
                else
                {
                    ViewBag.IsUnSub = true;
                    ViewBag.WrongMessage = "Invalid pin code.";
                    return View("Verify");
                }
            }
            else
            {
                ViewBag.WrongMessage = "please enter the pin code";
                return View("Verify");
            }
        }

        [HttpGet("UnSubscription")]
        [ServiceFilter(typeof(UserAuthenticationFilter))]
        public IActionResult UnSubUser()
        {
            ViewData["isUnSub"] = true;
            ViewBag.IsUnSub = true;
            return View("Index");
        }

        [ServiceFilter(typeof(UserAuthenticationFilter))]
        public async Task<IActionResult> UnSubUserFromDb()
        {
            var msisdn = HttpContext.Request.Cookies["MSISDN"];
            var response = await _swaggerClient.UnsubscribeUserAsync(new UnsubscribeUserCommand { Msisdn = msisdn });
            if (response.Success)
            {
                //await _swaggerClient.SendSmsAsync(PhoneNumber, false);
                HttpContext.Response.Cookies.Delete("MSISDN");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //ViewBag.WrongMessage = "Please enter the right code";
                ViewBag.WrongMessage = response.Message; // temp. solution till the testing phase
                return View("Index");
            }
        }

        public IActionResult LandingPage()
        {
            string langHeader = Request.Query["lang"];
            if (langHeader != null)
            {
                if (langHeader == "en")
                {
                    langHeader = "en";
                }
                else
                {
                    langHeader = "ar-EG";
                }

                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(langHeader)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

                return RedirectToAction("LandingPage");
            }
            return View();
        }

        public IActionResult Landing()
        {
            string langHeader = Request.Query["lang"];
            if (langHeader != null)
            {
                if (langHeader == "en")
                {
                    langHeader = "en";
                }
                else
                {
                    langHeader = "ar-EG";
                }

                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(langHeader)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

                return RedirectToAction("Landing");
            }
            return View();
        }

        public IActionResult SubscribeMail()
        {
            return View();
        }

        public IActionResult VerifyMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyMail(string otp)
        {
            string otpCookieStr = HttpContext.Request.Cookies["OTP"];
            if (otpCookieStr == null || otpCookieStr == "")
                return RedirectToAction("Landing");

            //TODO: Decrypt Cookie
            var otpCookie = JsonConvert.DeserializeObject<MailOTP>(otpCookieStr);
            if (otpCookie.Otp != otp)
            {
                ViewBag.WrongMessage = "Invalid Pin.";
                return View("VerifyMail");
            }

            string msisdnCookie = HttpContext.Request.Cookies["MSISDN"];
            var response = await _swaggerClient.SubscribeUserMailAsync(new UserMailDTO { Email = otpCookie.Email, Msisdn = msisdnCookie });

            if (response.Success != true)
                return RedirectToAction("VerifyMail");

            HttpContext.Response.Cookies.Delete("OTP");
            HttpContext.Response.Cookies.Append("EMAIL", otpCookie.Email, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddYears(1)
            });

            return RedirectToAction("Index", "Tournaments");
        }

        [HttpPost]
        public IActionResult SendOTP(string email)
        {
            if (email == null)
                return View("Landing");

            string otp = RandomOTP(4);

            var body = $"Dear User, <br/>Your OTP is {otp} for tournament subscription.";

            SendMail(email, "Umniah E-Sports OTP", body);

            var mailOTP = new MailOTP
            {
                Email = email,
                Otp = otp
            };

            string mailOtpSerialized = JsonConvert.SerializeObject(mailOTP);

            //TODO: Encrypt mailOTP

            HttpContext.Response.Cookies.Append("OTP", mailOtpSerialized, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddHours(6)
            });

            return RedirectToAction("VerifyMail");
        }

        private string RandomOTP(int length = 4)
        {
            Random _rdm = new Random();
            string otp = "";

            for (int i = 0; i < length; i++)
            {
                otp += _rdm.Next(0, 9).ToString();
            }

            return otp;
        }

        private void SendMail(string to, string subject, string body)
        {
            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential basicCredential = new NetworkCredential("mailing.service.101@gmail.com", "zvsbbwxqhfwmrydk");
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress("mailing.service.101@gmail.com");
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.Timeout = (60 * 1 * 1000); //Timeout 1 minute
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;

            message.IsBodyHtml = true;
            message.Subject = subject;
            message.Body = body;
            message.From = fromAddress;
            message.To.Add(to);

            smtpClient.Send(message);
            smtpClient.Dispose();
        }

        private string EncryptString(string tokenString)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(keyAES);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(tokenString);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        private string DecryptString(string decryptedToken)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(decryptedToken);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(keyAES);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

    public class MailOTP
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
