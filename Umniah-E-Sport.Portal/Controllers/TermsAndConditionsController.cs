using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Portal.ActionFilter;
using Umniah_E_Sport.Portal.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Portal.Controllers
{
    [ServiceFilter(typeof(UserMailAuthenticationFilter))]
    public class TermsAndConditionsController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        public TermsAndConditionsController(IConfiguration config)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
        }
        public async Task<IActionResult> Index(int tournamentId)
        {
            var termsAndConditions = await _swaggerClient.GetTermsAndConditionsAsync(tournamentId);
            var tournament = await _swaggerClient.GetTournamentAsync(tournamentId);
            var model = new TermsAndConditionsVm
            {
                Tournament = tournament,
                TermsAndConditions = termsAndConditions,
            };
            return View(model);
        }
    }
}
