using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Tool.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        public AchievementsController()
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Umniah-E-Sport/", new HttpClient());
        }
        // GET: AchievementsController
        public async Task<ActionResult> Index(int userId)
        {
            ViewBag.userId = userId;
            var achievements = await _swaggerClient.GetUserAchievementsByUserIdAsync(userId);
            return View(achievements);
        }

        // GET: AchievementsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var achievement = await _swaggerClient.GetAchievementByIdAsync(id);
            if (achievement != null)
            {
                return View(achievement);
            }
            return NotFound();
        }

        // GET: AchievementsController/Create
        public async Task<ActionResult> Create(int userId)
        {
            ViewBag.userId = userId;
            ViewBag.Badges = await _swaggerClient.BadgeAsync();
            return View();
        }

        // POST: AchievementsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddAchievementToUserCommand addAchievementToUserCommand)
        {
            var response = await _swaggerClient.AddAchievementToUserAsync(addAchievementToUserCommand);
            if (response == null)
            {
                return RedirectToAction(nameof(Index), new { userId = addAchievementToUserCommand.UserId });
            }
            return View();
        }

        // GET: AchievementsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var achievement = await _swaggerClient.GetAchievementByIdAsync(id);
            if (achievement != null)
            {
                ViewBag.Badges = await _swaggerClient.BadgeAsync();
                return View(achievement);
            }
            return NotFound();
        }

        // POST: AchievementsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, int userId, string name_EN, string name_AR, string imageName)
        {
            var response = await _swaggerClient.UpdateUserAchievementsAsync(id, userId, name_EN, name_AR, imageName);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index), new { userId = userId });
            }
            return View();
        }

        // GET: AchievementsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var achievement = await _swaggerClient.GetAchievementByIdAsync(id);
            if (achievement != null)
            {
                return View(achievement);
            }
            return NotFound();
        }

        // POST: AchievementsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, int userId, DeleteAchievementByIdVm deleteAchievementByIdVm)
        {
            var response = await _swaggerClient.DeleteAchievementByIdAsync(id);
            if (response == null)
            {
                return RedirectToAction(nameof(Index), new { userId = userId });
            }
            return View();
        }
    }
}
