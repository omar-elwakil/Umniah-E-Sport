using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Portal.ActionFilter;
using Umniah_E_Sport.Portal.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Helper.Managers.Portal;

namespace Umniah_E_Sport.Portal.Controllers
{
    [ServiceFilter(typeof(UserAuthenticationFilter))]
    public class UserProfileController : Controller
    {
        private readonly swaggerClient _swaggerClient;
        private readonly IUserManagerCookie _userManagerCookie;
        public UserProfileController(IUserManagerCookie userManagerCookie,IConfiguration config)
        {
            _swaggerClient = new swaggerClient(config.GetValue<string>("SwaggerSetting:SwaggerApiUrl"), new HttpClient());
            _userManagerCookie = userManagerCookie;
        }
        public async Task<IActionResult> Index()
        {
            var userMSISDN =  _userManagerCookie.GetUser();
            var userProfile = await _swaggerClient.GetUserProfileAsync(userMSISDN);
           
            
                if (userProfile == null)
                {
                    return NotFound("No user for this Phone number");
                }
            
            //var userUpcomingTournament = await _swaggerClient.GetUpcomingTournamentsAsync(userMSISDN);
            //var userLeaderBoard = await _swaggerClient.RankingLeaderBoardsAsync(userMSISDN, 10);
            //var userAchievements = await _swaggerClient.GetUserAchievementsByMsisdnAsync(userMSISDN);
            
            return View(userProfile);
            //return View("SmartLinkTest");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNameByMsisdn(string name, string Msisdn)
        {
            var userMSISDN = _userManagerCookie.GetUser();
            var userProfile = await _swaggerClient.GetUserProfileAsync(userMSISDN);
            try
            {
                if (userProfile == null)
                {
                    return NotFound("No user for this Phone number");
                }
                var response = await _swaggerClient.UpdateUserNameAsync(new UpdateUserProfileCommand { Msisdn = Msisdn, Name = name });

                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        public async Task<IActionResult> Achievement(string sessionId)
        {
            var userMSISDN = _userManagerCookie.GetUser();
            var achievement = await _swaggerClient.GetUserAchievementsByMsisdnAsync(userMSISDN);

            return View(achievement);
        }


        public async Task<IActionResult> MyLeaderboard() //TODO: Uncomment Msisdn part
        {
            var userMSISDN =_userManagerCookie.GetUser();
            var leaderBoard = await _swaggerClient.RankingLeaderBoardsAsync(userMSISDN, 11);
            /*  var model = new MyLeaderboardViewModel
              {
                  Game_Title_AR = leaderBoard.,
                  Game_Title_EN = leaderBoard.Title_EN,
                  ActiveLeaderboardIndex = 0,
                  Leaderboards = leaderBoard.LeaderBoardRankDTOs.ToList(),
              };*/
            try
            {
                return View(leaderBoard);
            }
            catch (Exception)
            {
                return View(leaderBoard);
            }
        }
    }
}
