using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Tool.Managers.Upload;
using Umniah_E_Sport.Tool.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class VideoController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private readonly IUploadFileManager _fileManager;

        public VideoController(IUploadFileManager fileManager)
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
            _fileManager = fileManager;
        }

        // GET: VideoController
        public async Task<ActionResult> Index()
        {
            return View(await _swaggerClient.AllVideosAsync());
        }

        // GET: VideoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _swaggerClient.VideoDetailsAsync(id));
        }

        // GET: VideoController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Games = await _swaggerClient.GetAllGamesAsync();
            return View();
        }

        // POST: VideoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddVideoToGameCommand command, IFormFile imageFile, IFormFile videoFile)
        {
            try
            {
                if (imageFile != null)
                {
                    command.ImageName = _fileManager.UploadVideoImage(imageFile);
                }
                if (videoFile != null)
                {
                    command.VideoFileName = _fileManager.UploadVideo(videoFile);
                }
                command.TimeStamp = System.DateTime.Now;
                var model = await _swaggerClient.AddVideosToGameAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Games = await _swaggerClient.GetAllGamesAsync();
            return View(await _swaggerClient.VideoDetailsAsync(id));
        }

        // POST: VideoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateVideoByIdCommand command, IFormFile imageFile, IFormFile videoFile)
        {
            try
            {
                if (imageFile != null)
                {
                    command.ImageName = _fileManager.UploadVideoImage(imageFile);
                }
                if (videoFile != null)
                {
                    command.VideoFileName = _fileManager.UploadVideo(videoFile);
                }
                command.Id = id;
                var model = await _swaggerClient.UpdateVideoByIdAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View(await _swaggerClient.VideoDetailsAsync(id));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _swaggerClient.VideoDetailsAsync(id));
        }

        // POST: VideoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DeleteVideoByIdVm vm)
        {
            try
            {
                var model = await _swaggerClient.DeleteVideoByIdAsync(id);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
