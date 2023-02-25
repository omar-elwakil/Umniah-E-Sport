using Umniah_E_Sport.Portal.ActionFilter;
using Umniah_E_Sport.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Helper.Managers;
using Newtonsoft.Json;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Portal.Controllers
{
    [ServiceFilter(typeof(UserAuthenticationFilter))]
    public class CasualGameController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private readonly SmartLinkApiClient _smartLinkApiClient;
        public CasualGameController(IConfiguration config, SmartLinkApiClient smartLinkApiClient)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
            _smartLinkApiClient = smartLinkApiClient;
        }
        public async Task<IActionResult> Index(int gameId)
        {
            //var game = await _swaggerClient.GetCasualGameByIdAsync(gameId);
            //return View(game);
            var game = await _smartLinkApiClient.GetAsync($"CasualGame/CasualGameById?gameId={gameId}");
            return View(JsonConvert.DeserializeObject<CasualGame>(game));
        }
        public async Task<IActionResult> CategoryCasualGames(int categoryId)
        {
            //var games = await _swaggerClient.GetAllCasualGamesByCategoryAsync(categoryId);
            //return View(games);
            var games = await _smartLinkApiClient.GetAsync($"CasualGame/AllCasualGamesByCategory?categoryId={categoryId}");
            return View(JsonConvert.DeserializeObject<ICollection<GetCasualGamesByCategoryIdVm>>(games));
        }
        public async Task<IActionResult> GetAllCasualGames()
        {
            //var games = await _swaggerClient.GetAllCasualGamesAsync();
            //return View(games);
            var games = await _smartLinkApiClient.GetAsync($"CasualGame/AllCasualGames");
            return View(JsonConvert.DeserializeObject<ICollection<GetAllCasualGamesVm>>(games));
        }

        [HttpPost]
        public async Task<IActionResult> DownlaodGameFile(int gameId)
        {
            await _smartLinkApiClient.GetAsync($"CasualGame/Request?casualGameId={gameId}&PortalId=4");
            var gameStr = await _smartLinkApiClient.GetAsync($"CasualGame/CasualGameById?gameId={gameId}");
            var game = JsonConvert.DeserializeObject<GetCasualGameByIdVm>(gameStr);

            //var game = await _swaggerClient.GetCasualGameByIdAsync(gameId);

            //string filename = game.GameLink;

            //if (filename == null)
            //    return NotFound("You sent empty file name");


            ////var path = "D:\\Games\\APKFiles\\BikeUp\\"+ filename;

            //if (!filename.Contains(".apk"))
            //{
            //    filename = filename + ".apk";
            //}
            //var path = "C:\\inetpub\\wwwroot\\Content\\Umniah-E-Sport\\APKFiles\\" + filename;

            //if (!System.IO.File.Exists(path))
            //{
            //    return NotFound("Not found game apk");
            //}

            ////C:\inetpub\wwwroot\Content\CasualGames\APKFiles

            //try
            //{
            //    var memory = new MemoryStream();
            //    using (var stream = new FileStream(path, FileMode.Open))
            //    {
            //        await stream.CopyToAsync(memory);
            //    }
            //    memory.Position = 0;

            //    return File(memory, "application/vnd.android.package-archive", Path.GetFileName(path));
            //}
            //catch (System.Exception)
            //{
            //    return BadRequest("Somthing wrong");
            //}
            return Redirect(game.GameLink);

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        //public IActionResult RedirectToGame([FromForm] string gameId)
        //{
        //    return RedirectToAction("GameLoading", new { gameId = gameId });
        //}
        public async Task<IActionResult> RedirectToGame([FromForm] string gameId)
        {
            await _smartLinkApiClient.GetAsync($"CasualGame/Request?casualGameId={gameId}&PortalId=4");
            return RedirectToAction("GameLoading", new { gameId = gameId });
        }

        public async Task<IActionResult> GameLoading(int gameId)
        {
            //var game = await _swaggerClient.GetCasualGameByIdAsync(gameId);
            var gameStr = await _smartLinkApiClient.GetAsync($"CasualGame/CasualGameById?gameId={gameId}");
            var game = JsonConvert.DeserializeObject<GetCasualGameByIdVm>(gameStr);
            if (game == null)
            {
                return NotFound("Game Not Found");
            }
            return View(game);
        }
    }
}
