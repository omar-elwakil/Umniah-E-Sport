using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Tool.Managers.Upload;
using Umniah_E_Sport.Tool.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class TournamentController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private readonly IUploadFileManager _fileManager;
        public TournamentController(IUploadFileManager fileManager)
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
            _fileManager = fileManager;
        }
        // GET: TournamentController
        public async Task<ActionResult> Index()
        {
            var tournaments = await _swaggerClient.GetAllTournamentsAsync();
            return View(tournaments);
        }

        // GET: TournamentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var tournament = await _swaggerClient.GetTournamentAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        // GET: TournamentController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Games = await _swaggerClient.GetAllGamesAsync();
            ViewBag.Locations = await _swaggerClient.GetAllLocationsAsync();
            ViewBag.TournamentTypes = await _swaggerClient.GetAllTournamentTypesAsync();
            ViewBag.Arenas = await _swaggerClient.GetAllArenasAsync();

            return View();
        }

        // POST: TournamentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateTournamentCommand command, IFormFile imageFile, IFormFile bannerFile, bool FeaturedReplaced)
        {
            if (imageFile != null)
            {

                command.ImageName = _fileManager.UploadTournamentImage(imageFile);
                command.BannerName = _fileManager.UploadTournamentBanner(bannerFile);
                command.IsFeatured = FeaturedReplaced;
            }
            var response = await _swaggerClient.CreateTournamentAsync(command);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: TournamentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Games = await _swaggerClient.GetAllGamesAsync();
            ViewBag.Locations = await _swaggerClient.GetAllLocationsAsync();
            ViewBag.TournamentTypes = await _swaggerClient.GetAllTournamentTypesAsync();
            ViewBag.Arenas = await _swaggerClient.GetAllArenasAsync();

            var tournament = await _swaggerClient.GetTournamentAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        // POST: TournamentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateTournamentCommand command, IFormFile imageFile, IFormFile bannerFile, bool FeaturedReplaced)
        {

            if (imageFile != null)
            {

                command.ImageName = _fileManager.UploadTournamentImage(imageFile);
            }
            if (bannerFile != null)
            {
                command.BannerName = _fileManager.UploadTournamentBanner(bannerFile);
            }
            command.IsFeatured = FeaturedReplaced;

            var response = await _swaggerClient.UpdateTournamentAsync(command);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: TournamentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var tournament = await _swaggerClient.GetTournamentAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        // POST: TournamentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DeleteTournamentCommand deleteTournamentCommand)
        {
            deleteTournamentCommand.TournamentId = id;
            var response = await _swaggerClient.DeleteTournamentAsync(deleteTournamentCommand);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<ActionResult> UserTournaments(int id)
        {
            var userTournaments = await _swaggerClient.GetTournamentsByUserIdAsync(id);
            return View(userTournaments);
        }
    }
}
