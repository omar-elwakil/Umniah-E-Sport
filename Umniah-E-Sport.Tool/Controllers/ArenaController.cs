using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Tool.Managers.Upload;
using Umniah_E_Sport.Tool.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class ArenaController : Controller
    {

        private readonly swaggerClient _swaggerClient;
        private readonly IUploadFileManager _fileManager;
        public ArenaController(IUploadFileManager fileManager)
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
            _fileManager = fileManager;
        }
        // GET: ArenaController
        public async Task<ActionResult> Index()
        {
            var model = await _swaggerClient.GetAllArenasAsync();
            return View(model);
        }

        // GET: ArenaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _swaggerClient.GetArenaAsync(id);

            return View(model);
        }

        // GET: ArenaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArenaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateArenaCommand command, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null)
                {

                    command.ImageName = _fileManager.UploadArenaImage(imageFile);
                }
                var model = await _swaggerClient.CreateArenaAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ArenaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _swaggerClient.GetArenaAsync(id);
            return View(model);
        }

        // POST: ArenaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateArenaCommand command, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null)
                {

                    command.ImageName = _fileManager.UploadArenaImage(imageFile);
                }
                command.Id = id;
                var model = await _swaggerClient.UpdateArenaAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ArenaController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _swaggerClient.GetArenaAsync(id);
            return View(model);
        }

        // POST: ArenaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DeleteArenaCommand command)
        {
            try
            {
                command.ArenaId = id;
                var model = await _swaggerClient.DeleteArenaAsync(command);
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