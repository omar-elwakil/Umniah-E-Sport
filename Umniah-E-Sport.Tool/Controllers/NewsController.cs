using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Tool.Managers.Upload;
using Umniah_E_Sport.Tool.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class NewsController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private readonly IUploadFileManager _fileManager;
        public NewsController(IUploadFileManager fileManager)
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
            _fileManager = fileManager;
        }

        // GET: NewsController
        public async Task<ActionResult> Index()
        {
            return View(await _swaggerClient.GetAllNewsAsync());
        }

        // GET: NewsController/Details/5
        public async Task<ActionResult> Details(int id)
        {

            return View(await _swaggerClient.GetNewsAsync(id));
        }

        // GET: NewsController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Games = await _swaggerClient.GetAllGamesAsync();
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateNewsCommand command, IFormFile imageFile)
        {
            try
            {

                if (imageFile != null)
                {

                    command.ImageName = _fileManager.UploadNewImage(imageFile);
                }
                command.TimeStamp = System.DateTime.Now;
                var model = await _swaggerClient.CreateNewsAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Games = await _swaggerClient.GetAllGamesAsync();
            return View(await _swaggerClient.GetNewsAsync(id));
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateNewsCommand command, IFormFile imageFile)
        {
            try
            {

                if (imageFile != null)
                {

                    command.ImageName = _fileManager.UploadNewImage(imageFile);
                }
                var model = await _swaggerClient.UpdateNewsAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View(id);
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _swaggerClient.GetNewsAsync(id));
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DeleteNewsCommand command)
        {
            try
            {
                command.Id = id;
                var model = await _swaggerClient.DeleteNewsAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View(id);
            }
            catch
            {
                return View();
            }
        }
    }
}
