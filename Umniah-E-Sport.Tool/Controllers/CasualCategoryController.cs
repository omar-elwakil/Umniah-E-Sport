using Umniah_E_Sport.Tool.Managers.Upload;
using Umniah_E_Sport.Tool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class CasualCategoryController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private readonly IUploadFileManager _fileManager;
        public CasualCategoryController(IUploadFileManager fileManager)
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
            _fileManager = fileManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _swaggerClient.GetAllCasualCategoriesAsync();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        public async Task<IActionResult> CreateAsync(CreateCasualCategoryCommand command, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null)
                {
                    command.ImageName = _fileManager.UploadCasualCategoryImage(imageFile);
                }
                var model = await _swaggerClient.CreateCasualCategoryAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _swaggerClient.GetCasualCategoryAsync(id);
            return View(model);
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateCasualCategoryCommand command, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null)
                {

                    command.ImageName = _fileManager.UploadCasualCategoryImage(imageFile);
                }

                command.Id = id;
                var model = await _swaggerClient.UpdateCasaulCategoryAsync(command);
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

            return View(await _swaggerClient.GetCasualCategoryAsync(id));
        }

        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,int TempParam)
        {
            try
            {
                var model = await _swaggerClient.DeleteCasualCategoryAsync(id);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return RedirectToAction("Delete",new { id  = id});
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id }) ;
            }
        }
    }
}
