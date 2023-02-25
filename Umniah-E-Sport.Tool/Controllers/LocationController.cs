using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Tool.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class LocationController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        public LocationController()
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
        }
        // GET: LocationController
        public async Task<ActionResult> Index()
        {
            var locations = await _swaggerClient.GetAllLocationsAsync();
            return View(locations);
        }

        // GET: LocationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await _swaggerClient.GetLocationByIdAsync(id);
            if (response.Success)
            {
                return View(response);
            }
            return NotFound();
        }

        // GET: LocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLocationCommand createLocationCommand)
        {
            var response = await _swaggerClient.CreateLocationAsync(createLocationCommand);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: LocationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _swaggerClient.GetLocationByIdAsync(id);
            if (response.Success)
            {
                return View(response);
            }
            return NotFound();
        }

        // POST: LocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateLocationCommand updateLocationCommand)
        {
            updateLocationCommand.Id = id;
            var response = await _swaggerClient.UpdateLocationAsync(updateLocationCommand);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: LocationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _swaggerClient.GetLocationByIdAsync(id);
            if (response.Success)
            {
                return View(response);
            }
            return NotFound();
        }

        // POST: LocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DeleteLocationCommand deleteLocationCommand)
        {
            deleteLocationCommand.Id = id;
            var response = await _swaggerClient.DeleteLocationAsync(deleteLocationCommand);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
