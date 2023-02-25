using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Umniah_E_Sport.Tool.Managers.Upload;
using Umniah_E_Sport.Tool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class UploadUsersTournamentScoreCSVController : Controller
    {
        private readonly IConfiguration _config;
        private readonly swaggerClient _swaggerClient;
        private readonly IUploadFileManager _uploadFileManager;
        public UploadUsersTournamentScoreCSVController(IConfiguration config, IUploadFileManager uploadFileManager)
        {
            _config = config;
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
            _uploadFileManager = uploadFileManager;
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IFormFile uploadedFile)
        {
            if (uploadedFile == null)
            {
                ViewBag.Message = "Please upload csv file";
                return View(uploadedFile);
            }
            string root = _config.GetValue<string>("GlobalPath:Root");
            string path = _config.GetValue<string>("GlobalPath:UploadCSVFile");

            var fileEx = Path.GetExtension(uploadedFile.FileName);
            if (fileEx == ".csv")
            {
                //string newFileName = UploadFile(uploadedFile);
                string filePath = _uploadFileManager.UploadCSV(uploadedFile);
                //string filePath = root + path + newFileName;

                List<AddUsersScoresCommandItem> users = GetDataFromExcel(filePath);

                if (string.IsNullOrEmpty(filePath) || users == null)
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    return NotFound("Somthing Wrong");
                }
                else if (users.Count == 0)
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    ViewBag.Message = "Please insert data, or you missed header in csv file";
                    return View(uploadedFile);
                }
                // start of send data
                var response = await _swaggerClient.AddUsersTournamentScoresAsync(new AddUsersScoresCommand { AddUsersScoresCommandList = users });

                if (response.Success)
                {
                    TempData["Message"] = "Success";
                }
                else
                {
                    TempData["Message"] = "Fail";
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = "Please upload csv file";
            return View(uploadedFile);
        }

        private List<AddUsersScoresCommandItem> GetDataFromExcel(string filePath)
        {
            var users = new List<AddUsersScoresCommandItem>();
            //var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            //var fileName = $"{_config.GetValue<string>("UploadCSVFile")}{fName}";
            if (System.IO.File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath, Encoding.Default))
                {
                    using (var csv = new CsvReader((IParser)reader))
                    {
                        try
                        {

                            csv.Context.RegisterClassMap<MessageMap>(); //edit from Configuration to Context
                              
                            users = csv.GetRecords<AddUsersScoresCommandItem>().ToList();
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    }

                }
                //foreach (var item in usersMSISDN)
                //{
                //    msisdn.Status = UserEnum.UnSend;
                //}
                return users;
            }
            else
            {
                return null;
            }
        }

        public sealed class MessageMap : ClassMap<AddUsersScoresCommandItem>
        {
            public MessageMap()
            {
                Map(x => x.Msisdn);
                Map(x => x.DiscordLink);
                Map(x => x.UserScore);
            }
        }
    }
}
