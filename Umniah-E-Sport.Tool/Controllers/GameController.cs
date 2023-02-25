using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Tool.Managers.Upload;
using Umniah_E_Sport.Tool.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class GameController : Controller
    {

        private readonly swaggerClient _swaggerClient;
        private readonly IUploadFileManager _fileManager;
        public GameController(IUploadFileManager fileManager)
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
            _fileManager = fileManager;
        }
        // GET: GameController
        public async Task<ActionResult> Index()
        {
            var model = await _swaggerClient.GetAllGamesAsync();
            return View(model);
        }

        // GET: GameController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _swaggerClient.GetGameAsync(id);
            return View(model);
        }

        // GET: GameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddGameCommand command, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null)
                {

                    command.ImageName = _fileManager.UploadGameImage(imageFile);
                }
                command.CreationTimeStamp = System.DateTime.Now;
                var model = await _swaggerClient.AddGameAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: GameController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _swaggerClient.GetGameAsync(id);
            return View(model);
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateGameCommand command, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null)
                {

                    command.ImageName = _fileManager.UploadGameImage(imageFile);
                }

                command.Id = id;
                var model = await _swaggerClient.EditGameAsync(command);
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

            return View(await _swaggerClient.GetGameAsync(id));
        }

        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DeleteGameCommand command)
        {
            try
            {
                command.Id = id;
                var model = await _swaggerClient.DeleteGameAsync(command);
                if (model.Success)
                    return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> UserGames(int id)
        {
            var userGames = await _swaggerClient.GetUserGamesByUserIdAsync(id);
            return View(userGames);
        }
    }
}
