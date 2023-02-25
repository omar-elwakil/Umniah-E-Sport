using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Portal.ActionFilter;
using Umniah_E_Sport.Portal.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Portal.Controllers
{
    [ServiceFilter(typeof(UserAuthenticationFilter))]
    public class GameController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private const int TRENDING_GAME_COUNT = 4;
        public GameController(IConfiguration config)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
        }

        public async Task<IActionResult> Index()
        {
            var games = await _swaggerClient.GetAllGamesAsync();
            return View(games);
        }
        public async Task<IActionResult> TrendingGlimpse()
        {
            var games = await _swaggerClient.GetTrendingGamesAsync(TRENDING_GAME_COUNT);
            return View(games);
        }
        public async Task<IActionResult> Trending()
        {
            var games = await _swaggerClient.GetTrendingGamesAsync(-1);
            return View(games);
        }
        public async Task<IActionResult> RedirectToGameUrl(int tournamentId)
        {
            var response = await _swaggerClient.GetGameLinkAsync(tournamentId);
            if(response.Success)
            {
                return Redirect(response.GameLink);
            }
            return BadRequest(response);
        }

    }
}
