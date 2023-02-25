using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, GetUserProfileVM>
    {
        private readonly IUserManager _userRepo;
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;
        private readonly IAchievementManager _achievementRepo;
        public GetUserProfileQueryHandler(IUserManager userRepo, ITournamentManager tournamentRepo, IMapper mapper, IAchievementManager achievementRepo)
        {
            _userRepo = userRepo;
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
            _achievementRepo = achievementRepo;
        }

        public async Task<GetUserProfileVM> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            GetUserProfileVM vm = new GetUserProfileVM();

            var user = _userRepo.GetByMSISDN(request.MSISDN);

            if (user == null) { return null; }

            vm = _mapper.Map<GetUserProfileVM>(user);

            var userTournaments = _tournamentRepo.GetUpcomingTournamentsByUser(request.MSISDN);

            vm.UpcomingTournaments = _mapper.Map<List<UserProfileTournamentsVM>>(userTournaments);

            var userLeaderBaord = await _userRepo.GetUserLeaderBoard(request.MSISDN);

            vm.LeaderBoard = _mapper.Map<List<UserProfileGameScoreVM>>(userLeaderBaord);

            vm.Achievements = _mapper.Map<List<UserProfileAchievmentsVM>>(user.Achievements.Take(6));

            return vm;
        }
    }
}
