using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Portal.ActionFilter;
using Umniah_E_Sport.Portal.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Portal.Controllers
{
    [ServiceFilter(typeof(UserAuthenticationFilter))]
    public class NewsController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private const int NEWS_COUNT = 5;
        public NewsController(IConfiguration config)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
        }
        public async Task<IActionResult> Index()
        {
            var news = await _swaggerClient.GetAllNewsAsync();
            return View(news);
        }      
        public async Task<IActionResult> Latest()
        {
            var news = await _swaggerClient.GetLatestNewsAsync(NEWS_COUNT);
            return View(news);
        }
        public async Task<IActionResult> Details(int newsId)
        {
            var news = await _swaggerClient.GetNewsAsync(newsId);   
            if(news == null)
            {
                return NotFound();
            }
            return View(news);
        }
    }
}
