using Umniah_E_Sport.Tool.Managers.Upload;
using Umniah_E_Sport.Tool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class CasualGameImagesController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private readonly IUploadFileManager _fileManager;

        public CasualGameImagesController(IUploadFileManager fileManager)
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
            _fileManager = fileManager;
        }

        public async Task<IActionResult> Index(int casualGameId)
        {
            var result = await _swaggerClient.GetCasualGameByIdAsync(casualGameId);
            return View(result);
        }
        public IActionResult Create(int casualGameId)
        {
            return View(new CreateCasualGameImageCommand { CasualGameId = casualGameId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        public async Task<IActionResult> CreateAsync(CreateCasualGameImageCommand command, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null)
                {
                    command.ImageName = _fileManager.UploadCasualGameImage(imageFile);
                }

                var model = await _swaggerClient.CreateCasualGameImageAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index),new {casualGameId = command.CasualGameId});
                else return View();
            }
            catch
            {
                return View();
            }
        }
        // POST: GameController/Delete/5
        public async Task<ActionResult> Delete(int id,int casualGameId)
        {
            var model = await _swaggerClient.DeleteCasualGameImageAsync(id);
            return RedirectToAction(nameof(Index), new { casualGameId = casualGameId });
        }
    }
}
