using Umniah_E_Sport.Tool.Managers.Upload;
using Umniah_E_Sport.Tool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class CasualGameController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private readonly IUploadFileManager _fileManager;
        public CasualGameController(IUploadFileManager fileManager)
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
            _fileManager = fileManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _swaggerClient.GetAllCasualGamesAsync();
            return View(result);
        }
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.CasualCategories = await _swaggerClient.GetAllCasualCategoriesAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        public async Task<IActionResult> CreateAsync(CreateCasualGameCommand command, IFormFile bannerImageFile,IFormFile ThumbnailImageFile)
        {
            try
            {
                if (bannerImageFile != null)
                {
                    command.BannerImageName = _fileManager.UploadCasualGameBannerImage(bannerImageFile);
                }
                if (ThumbnailImageFile != null)
                {
                    command.ThumbnailImageName = _fileManager.UploadCasualGameThumbnailImage(ThumbnailImageFile);
                }
                
                var model = await _swaggerClient.CreateCasualGameAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Details(int id)
        {
            var model = await _swaggerClient.GetCasualGameByIdAsync(id);
            return View(model);
        }

        public async Task<ActionResult> Edit(int id)
        {

            ViewBag.CasualCategories = await _swaggerClient.GetAllCasualCategoriesAsync();
            var model = await _swaggerClient.GetCasualGameByIdAsync(id);
            return View(model);
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateCasualGameCommand command, IFormFile bannerImageFile, IFormFile ThumbnailImageFile)
        {
            try
            {
                if (bannerImageFile != null)
                {
                    command.BannerImageName = _fileManager.UploadCasualGameBannerImage(bannerImageFile);
                }
                if (ThumbnailImageFile != null)
                {
                    command.ThumbnailImageName = _fileManager.UploadCasualGameThumbnailImage(ThumbnailImageFile);
                }

                command.Id = id;
                var model = await _swaggerClient.UpdateCasaulGameAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: GameController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            return View(await _swaggerClient.GetCasualGameByIdAsync(id));
        }

        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, int TempParam)
        {
            try
            {
                var model = await _swaggerClient.DeleteCasualGameAsync(id);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return RedirectToAction("Delete", new { id = id });
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id });
            }
        }
    
}
}
