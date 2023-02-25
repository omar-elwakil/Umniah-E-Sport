
using Umniah_E_Sport.Application.Responses;
using Umniah_E_Sport.Domain;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Umniah_E_Sport.Application.Contracts.Persistence;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Features.Users.Queries.GenerateOTP;

namespace Umniah_E_Sport.Persistence.Repo
{
    public class SubscriptionRepo : ISubscriptionManager
    {
        private readonly IntegrationConfig _integrationConfig;

        public SubscriptionRepo(IOptions<IntegrationConfig> config)
        {
            _integrationConfig = config.Value;
        }

        public async Task<GenerateOTPQueryResponse> GenerateOTP(string msisdn)
        {
            string URL = _integrationConfig.GenerateOTPURL;
            URL = URL.Replace("@@HOST@@", _integrationConfig.HOST);
            URL = URL.Replace("@@USER@@", _integrationConfig.User);
            URL = URL.Replace("@@PASSWORD@@", _integrationConfig.Password);
            URL = URL.Replace("@@MSISDN@@", msisdn);
            URL = URL.Replace("@@SHORTCODE@@", _integrationConfig.ShortCode);
            URL = URL.Replace("@@SERVICEID@@", _integrationConfig.ServiceId);
            URL = URL.Replace("@@SPID@@", _integrationConfig.SpId);
            var client = new RestClient(URL);
           // client.Timeout = -1;
            var request = new RestRequest();
            request.Method = Method.Get;
            RestResponse response = client.Execute(request);
            if (response.Content.Contains("Success"))
            {
                return await Task.FromResult(new GenerateOTPQueryResponse { Success = true });
            }
            else
            {
                dynamic data = JObject.Parse(response.Content);
                return await Task.FromResult(new GenerateOTPQueryResponse { Success = false, Message = data.msg });
            }
        }

        public async Task<BaseResponse> ValidateOTP(string msisdn, string otp)
        {
            string URL = _integrationConfig.ValidateOTPURL;
            URL = URL.Replace("@@HOST@@", _integrationConfig.HOST);
            URL = URL.Replace("@@USER@@", _integrationConfig.User);
            URL = URL.Replace("@@PASSWORD@@", _integrationConfig.Password);
            URL = URL.Replace("@@MSISDN@@", msisdn);
            URL = URL.Replace("@@SHORTCODE@@", _integrationConfig.ShortCode);
            URL = URL.Replace("@@SERVICEID@@", _integrationConfig.ServiceId);
            URL = URL.Replace("@@SPID@@", _integrationConfig.SpId);
            URL = URL.Replace("@@PINCODE@@", otp);

            var client = new RestClient(URL);
           // client.Timeout = -1;
            var request = new RestRequest();
            request.Method = Method.Get;
            RestResponse response = client.Execute(request);
            if (response.Content.Contains("Success"))
            {
                return await Task.FromResult(new BaseResponse { Success = true });
            }
            else
            {
                dynamic data = JObject.Parse(response.Content);
                return await Task.FromResult(new BaseResponse { Success = false, Message = data.msg });
            }
        }
        public BaseResponse UnSubscribeUser(string msisdn)
        {
            string URL = _integrationConfig.UnSubscriptioncribeURL;
            URL = URL.Replace("@@HOST@@", _integrationConfig.HOST);
            URL = URL.Replace("@@USER@@", _integrationConfig.User);
            URL = URL.Replace("@@PASSWORD@@", _integrationConfig.Password);
            URL = URL.Replace("@@MSISDN@@", msisdn);
            URL = URL.Replace("@@SHORTCODE@@", _integrationConfig.ShortCode);
            URL = URL.Replace("@@SERVICEID@@", _integrationConfig.ServiceId);
            URL = URL.Replace("@@SPID@@", _integrationConfig.SpId);

            var client = new RestClient(URL);
           // client.Timeout = -1;
            var request = new RestRequest();
            request.Method = Method.Get;
            RestResponse response = client.Execute(request);
            if (response.Content.Contains("Success"))
            {
                return new BaseResponse { Success = true };
            }
            else
            {
                dynamic data = JObject.Parse(response.Content);
                return new BaseResponse { Success = false, Message = data.msg };
            }
        }

        public BaseResponse SendSMS(string msisdn, bool isSMSSubscribe)
        {
            string URL = _integrationConfig.SendSMSURL;
            URL = URL.Replace("@@HOST@@", _integrationConfig.HOST);
            URL = URL.Replace("@@USER@@", _integrationConfig.User);
            URL = URL.Replace("@@PASSWORD@@", _integrationConfig.Password);
            URL = URL.Replace("@@MSISDN@@", msisdn);
            URL = URL.Replace("@@SHORTCODE@@", _integrationConfig.ShortCode);
            URL = URL.Replace("@@SERVICEID@@", _integrationConfig.ServiceId);
            URL = URL.Replace("@@MSG@@",isSMSSubscribe ? _integrationConfig.SubscribeSMS : _integrationConfig.UnSubscribeSMS);
            URL = URL.Replace("@@ALPHANUMERIC@@", _integrationConfig.Alphanumeric);

            var client = new RestClient(URL);
           // client.Timeout = -1;
            var request = new RestRequest();
            request.Method = Method.Get;
            RestResponse response = client.Execute(request);
            if (response.Content.Contains("Success"))
            {
                return new BaseResponse { Success = true };
            }
            else
            {
                dynamic data = JObject.Parse(response.Content);
                return new BaseResponse { Success = false, Message = data.msg };
            }
        }

        public BaseResponse SendSMS(string msisdn, string content)
        {
            string URL = _integrationConfig.SendSMSURL;
            URL = URL.Replace("@@HOST@@", _integrationConfig.HOST);
            URL = URL.Replace("@@USER@@", _integrationConfig.User);
            URL = URL.Replace("@@PASSWORD@@", _integrationConfig.Password);
            URL = URL.Replace("@@MSISDN@@", msisdn);
            URL = URL.Replace("@@SHORTCODE@@", _integrationConfig.ShortCode);
            URL = URL.Replace("@@SERVICEID@@", _integrationConfig.ServiceId);
            URL = URL.Replace("@@MSG@@", UnicodeStr2HexStr(content));
            URL = URL.Replace("@@SPID@@", _integrationConfig.SpId);
            URL = URL.Replace("@@ALPHANUMERIC@@", _integrationConfig.Alphanumeric);
            URL = URL.Replace("@@TRANSACTIONID@@", RandomString(20));

            var client = new RestClient(URL);
           // client.Timeout = -1;
            var request = new RestRequest();
            request.Method = Method.Get;
            RestResponse response = client.Execute(request);
            if (response.Content.Contains("Success"))
            {
                return new BaseResponse { Success = true };
            }
            else
            {
                dynamic data = JObject.Parse(response.Content);
                return new BaseResponse { Success = false, Message = data.msg };
            }
        }

        private static string UnicodeStr2HexStr(string strMessage)
        {
            byte[] ba = Encoding.BigEndianUnicode.GetBytes(strMessage);
            string strHex = BitConverter.ToString(ba);
            strHex = strHex.Replace("-", "");
            return strHex;
        }

        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
