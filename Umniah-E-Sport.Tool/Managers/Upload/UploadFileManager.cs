using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Umniah_E_Sport.Tool.Managers.Upload
{
    public interface IUploadFileManager
    {
        public string UploadVideo(IFormFile file);
        public string UploadVideoImage(IFormFile file);
        public string UploadVideoThumbnail(IFormFile file);
        public string UploadTournamentImage(IFormFile file);
        public string UploadTournamentBanner(IFormFile file);
        public string UploadArenaImage(IFormFile file);
        public string UploadGameImage(IFormFile file);
        public string UploadCasualCategoryImage(IFormFile file);
        public string UploadCasualGameThumbnailImage(IFormFile file);
        public string UploadCasualGameBannerImage(IFormFile file);
        public string UploadCasualGameImage(IFormFile file);
        public string UploadBadgeImage(IFormFile file);
        public string UploadNewImage(IFormFile file);
        public string UploadCSV(IFormFile file);
    }
    public class UploadFileManager : IUploadFileManager
    {
        private readonly IConfiguration _config;

        public UploadFileManager(IConfiguration config)
        {
            _config = config;
        }

        public string UploadArenaImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:ArenasImagePath");
            return UploadFile(path, file);
        }

        public string UploadBadgeImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:BadgePath");
            return UploadFile(path, file);
        }

        public string UploadCSV(IFormFile file)
        {
            string root = _config.GetValue<string>("GlobalPath:Root");
            string path = _config.GetValue<string>("GlobalPath:UploadCSVFile");
            string fileName = UploadFile(path, file);
            return (fileName != null) ? root + path + fileName : null;
        }

        public string UploadGameImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:GameImagePath");
            return UploadFile(path, file);
        }

        public string UploadNewImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:NewsPath");
            return UploadFile(path, file);
        }

        public string UploadTournamentImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:TournamentsImagePath");
            return UploadFile(path, file);
        }

        public string UploadTournamentBanner(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:TournamentsBannerPath");
            return UploadFile(path, file);
        }

        public string UploadVideo(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:VideoPath");
            return UploadFile(path, file);
        }

        public string UploadVideoImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:VideoImagesPath");
            return UploadFile(path, file);
        }

        public string UploadVideoThumbnail(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:VideoThumbnailsPath");
            return UploadFile(path, file);
        }

        private string UploadFile(string path, IFormFile file)
        {
            string root = _config.GetValue<string>("GlobalPath:Root");
            string result = string.Empty;
            string fileWithExt = null;
            try
            {
                //var filenameDate = (file.FileName + "-" + DateTime.Now).Trim('"');
                string FilePath = $"{root}{path}{file.FileName}";
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(FilePath);
                fileWithExt = fileNameWithoutExt + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + Path.GetExtension(file.FileName);
                fileWithExt = fileWithExt.Trim('"');
                FilePath = $"{root}{path}{fileWithExt}";
                //FilePath = webHostEnvironment.WebRootPath + $@"\{ fileNameWithoutExt}";
                using (FileStream fileStream = System.IO.File.Create(FilePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }

            }
            catch (Exception ex)
            {
                result = ex.Message;
                return null;
            }
            return fileWithExt;
        }

        public string UploadCasualCategoryImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:CasualCategoryPath");
            return UploadFile(path, file);
        }

        public string UploadCasualGameThumbnailImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:CasualGameThumbnailPath");
            return UploadFile(path, file);
        }
        
        public string UploadCasualGameBannerImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:CasualGameBannerPath");
            return UploadFile(path, file);
        }

        public string UploadCasualGameImage(IFormFile file)
        {
            string path = _config.GetValue<string>("GlobalPath:CasualGameImagePath");
            return UploadFile(path, file);
        }
    }
}
