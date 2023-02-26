using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Portal.ActionFilter;
using Umniah_E_Sport.Portal.Models;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Helper.Managers.Portal;

namespace Umniah_E_Sport.Portal.Controllers
{
   [ServiceFilter(typeof(UserMailAuthenticationFilter))]
    public class TournamentsController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private readonly IUserManagerCookie _cookieManager;
        public TournamentsController(IUserManagerCookie cookieManager,IConfiguration config)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
            //_swaggerClient = new swaggerClient("http://api.sltech.org/Jawwal-E-Sport/", new HttpClient());
            _cookieManager = cookieManager;
        }
        public async Task<IActionResult> Index()
        {
            var tournaments = await _swaggerClient.GetAllTournamentsAsync();
            return View(tournaments);
        }

        public async Task<IActionResult> Featured()
        {
            return View(await _swaggerClient.GetFeatureTournamentsAsync());
        }

        public async Task<IActionResult> Details(int tournamentId )
        {
            try
            {
                string email = _cookieManager.GetUserEmail();
                
                if (email != null)
                {
                    var response = await _swaggerClient.IsUserAlreadyJoinTournamentAsync(email, tournamentId);
                    if (response.Success && response.IsExist)
                    {
                        return View("LaunchGame", await TournamentDetails(tournamentId));
                    }
                }
            }
            catch (Exception ex) { }
            var model = await _swaggerClient.GetTournamentAsync(tournamentId);
            return View(model);
        }

        public async Task<IActionResult> Upcoming()
        {
            var email = _cookieManager.GetUserEmail();

            var upcomingTournaments = await _swaggerClient.GetUpcomingTournamentsAsync(email);

            return View(upcomingTournaments);

        }

        public async Task<IActionResult> Live()
        {
            var email = _cookieManager.GetUserEmail();

            var upcomingTournaments = await _swaggerClient.GetLiveTournamentsAsync(email);

            return View(upcomingTournaments);

        }

        public async Task<IActionResult> Finished()
        {
            var email = _cookieManager.GetUserEmail();

            var upcomingTournaments = await _swaggerClient.GetFinishedTournamentsAsync(email);

            return View(upcomingTournaments);

        }

        public async Task<IActionResult> ByGame(int gameId)
        {
            var model = await _swaggerClient.GetTournamentsByGameIdAsync(gameId);
            return View(model);
        }

        public async Task<IActionResult> MyTournaments()
        {
            UserTournamentsVM model = new UserTournamentsVM();
            var email = _cookieManager.GetUserEmail();

            model.UpcomingTournaments = await _swaggerClient.GetUpcomingTournamentsAsync(email);
            model.LiveTournaments = await _swaggerClient.GetLiveTournamentsAsync(email);
            model.FinishedTournaments = await _swaggerClient.GetFinishedTournamentsAsync(email);

            return View(model);
        }

        public async Task<IActionResult> JoinTournament(int TournamentId)
        {
            return View(await TournamentDetails(TournamentId));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserTournaments(string userName, int tournamentId, string ingameId)
        {
            var msisdn = _cookieManager.GetUser();
            var email = _cookieManager.GetUserEmail();
            RegisteredUserTournmentsCommand command = new RegisteredUserTournmentsCommand
            {
                UserName = userName,
                TournamentId = tournamentId,
                IngameId = ingameId,
                Msisdn = msisdn,
                Email = email
            };
            var response = await _swaggerClient.JoinUserTournamentAsync(command);
            if (response.Success)
            {
                return RedirectToAction("ConfirmationSucsess", new { tournamentId = tournamentId });
            }
            return RedirectToAction(nameof(Index));
        }


        private async Task<GetTournamentVM> TournamentDetails(int tournamentId)
        {
            var tournament = await _swaggerClient.GetTournamentAsync(tournamentId);
            return tournament;
        }
        public async Task<IActionResult> ConfirmationSucsess(int tournamentId)
        {
            try
            {
                return View(await TournamentDetails(tournamentId));
            }
            catch(Exception ex) { }
            return View(await TournamentDetails(2002) );
        }

        public async Task<IActionResult> LaunchGame(int tournamentId)
        {

            var tournament = await TournamentDetails(tournamentId);
            return View(tournament);
        }

    }
}
