using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Portal.ActionFilter;
using Umniah_E_Sport.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Portal.Controllers
{
    [ServiceFilter(typeof(UserAuthenticationFilter))]
    public class ArenaController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        //private readonly IConfiguration _config;
        public ArenaController(IConfiguration config)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
            //_config = config;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _swaggerClient.GetAllArenasAsync();
            return View(model);
        }

        public async Task<IActionResult> Tournaments(int arenaId)
        {
            var model = new ArenaTournamentsVM
            {
                LiveTournaments = await _swaggerClient.GetLiveTournamentsByArenaIdAsync(arenaId),
                FinishedTournaments = await _swaggerClient.GetFinishedTournamentsByArenaIdAsync(arenaId),
                UpcomingTournaments = await _swaggerClient.GetUpcomingTournamentsByArenaIdAsync(arenaId),
            };

            return View(model);
        }
    }
}
