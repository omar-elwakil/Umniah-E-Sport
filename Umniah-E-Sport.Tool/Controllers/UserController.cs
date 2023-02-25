using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Tool.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Tool.Controllers
{
    public class UserController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        public UserController()
        {
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
        }
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var users = await _swaggerClient.GetAllUsersOrderedByScoreAsync();
            return View(users);
        }
    }
}
