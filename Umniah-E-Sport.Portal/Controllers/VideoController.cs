using Umniah_E_Sport.Portal.ActionFilter;
using Umniah_E_Sport.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Portal.Controllers
{
    [ServiceFilter(typeof(UserAuthenticationFilter))]
    public class VideoController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        public VideoController(IConfiguration config)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
        }
        public async Task<IActionResult> Index()
        {
            var videos = await _swaggerClient.AllVideosAsync();
            return View(videos);
        }
        public async Task<IActionResult> Latest()
        {
            var videos = await _swaggerClient.LatestVideosAsync();
            return View(videos);
        }
        public async Task<IActionResult> Details(int videoId)
        {
            var video = await _swaggerClient.VideoDetailsAsync(videoId);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }
    }
}
