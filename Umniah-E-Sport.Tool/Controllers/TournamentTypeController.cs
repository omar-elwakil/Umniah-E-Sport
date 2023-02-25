using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Tool.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class TournamentTypeController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        public TournamentTypeController()
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
        }
        // GET: TournamentTypeController
        public async Task<ActionResult> Index()
        {
            var tournamentTypes = await _swaggerClient.GetAllTournamentTypesAsync();
            return View(tournamentTypes);
        }


        // GET: TournamentTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TournamentTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateTournamentTypeCommand createTournamentTypeCommand)
        {
            var response = await _swaggerClient.CreateTournamentTypeAsync(createTournamentTypeCommand);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: TournamentTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _swaggerClient.GetTournamentTypeByIdAsync(id);
            if (response.Success)
            {
                return View(response);
            }
            return NotFound();
        }

        // POST: TournamentTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateTournamentTypeCommand updateTournamentTypeCommand)
        {
            var response = await _swaggerClient.UpdateTournamentTypeAsync(updateTournamentTypeCommand);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: TournamentTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _swaggerClient.GetTournamentTypeByIdAsync(id);
            if (response.Success)
            {
                return View(response);
            }
            return NotFound();
        }

        // POST: TournamentTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DeleteTournamentTypeCommand deleteTournamentTypeCommand)
        {
            deleteTournamentTypeCommand.Id = id;
            var response = await _swaggerClient.DeleteTournamentTypeAsync(deleteTournamentTypeCommand);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
