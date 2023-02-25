using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Portal.Models;
using Microsoft.AspNetCore.Localization;
using Umniah_E_Sport.Portal;
using Newtonsoft.Json;
using UI.Helper.Managers;

namespace Umniah_E_Sport.Portal.Controllers
{
    //[ServiceFilter(typeof(UserAuthenticationFilter))]
    public class HomeController : Controller
    {

        private readonly swaggerClient _swaggerClient;
        private readonly SmartLinkApiClient _smartLinkApiClient;
        private const int LATEST_GAMES_COUNT = 4;
        public HomeController(IConfiguration config, SmartLinkApiClient smartLinkApiClient)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
            _smartLinkApiClient = smartLinkApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var cookie = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            string MSISDN = Request.Query["MSISDN"].ToString();
            if (MSISDN == "SmartLinkTest")
                Response.Cookies.Append("MSISDN", "SmartLinkTest", new CookieOptions { Expires = DateTime.Now.AddMinutes(5) });

            if (cookie != null)
            {
                if (cookie.Contains("en")) ViewBag.lang = "en"; else ViewBag.lang = "ar";
            }
            else
            {
                ViewBag.lang = "ar";
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("ar")),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

                return RedirectToAction("Index");
            }

            var arenas = await _swaggerClient.GetAllArenasAsync();
            var games = await _swaggerClient.GetAllGamesAsync();
            var latestNews = await _swaggerClient.GetLatestNewsAsync(LATEST_GAMES_COUNT);
            var featuredTournaments = await _swaggerClient.GetFeatureTournamentsAsync();
            var latestVideos = await _swaggerClient.LatestVideosAsync(); // first 4 
            var featuredCasualGamesStr = await _smartLinkApiClient.GetAsync("CasualGame/FeaturedCasualGames?count=6");
            var featuredCasualGames = JsonConvert.DeserializeObject<ICollection<GetFeaturedCasualGamesVm>>(featuredCasualGamesStr);
            var casualCategoriesStr = await _smartLinkApiClient.GetAsync("CasualCategory/Get-All-Casual-Categories");
            var casualCategories = JsonConvert.DeserializeObject<ICollection<GetAllCasualCategoriesVm>>(casualCategoriesStr);
            //var featuredCasualGames = await _swaggerClient.GetFeaturedCasualGamesAsync(100);
            //var casualCategories = await _swaggerClient.GetAllCasualCategoriesAsync();

            var homeVm = new HomeVm
            {
                Arenas = arenas,
                Games = games,
                News = latestNews,
                Tournaments = featuredTournaments,
                Videos = latestVideos,
                FeaturedCasualGames = featuredCasualGames,
                CatualCategories = casualCategories
            };


            return View(homeVm);
        }
    }
}
