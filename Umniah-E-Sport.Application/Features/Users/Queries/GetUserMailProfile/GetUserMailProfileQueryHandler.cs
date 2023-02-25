using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUserMailProfile
{
    public class GetUserMailProfileQueryHandler : IRequestHandler<GetUserMailProfileQuery, GetUserMailProfileVM>
    {
        private readonly IUserManager _userRepo;
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;
        private readonly IAchievementManager _achievementRepo;
        public GetUserMailProfileQueryHandler(IUserManager userRepo, ITournamentManager tournamentRepo, IMapper mapper, IAchievementManager achievementRepo)
        {
            _userRepo = userRepo;
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
            _achievementRepo = achievementRepo;
        }

        public async Task<GetUserMailProfileVM> Handle(GetUserMailProfileQuery request, CancellationToken cancellationToken)
        {
            GetUserMailProfileVM vm = new GetUserMailProfileVM();

            var user = _userRepo.GetByMSISDN(request.MSISDN);

            if (user == null) { return null; }

            vm = _mapper.Map<GetUserMailProfileVM>(user);

            var userTournaments = _tournamentRepo.GetUpcomingTournamentsByUser(request.MSISDN);

            vm.UpcomingTournaments = _mapper.Map<List<UserMailProfileTournamentsVM>>(userTournaments);

            var userLeaderBaord = await _userRepo.GetUserLeaderBoard(request.MSISDN);

            vm.LeaderBoard = _mapper.Map<List<UserMailProfileGameScoreVM>>(userLeaderBaord);

            vm.Achievements = _mapper.Map<List<GetUserMailProfileAchievmentsVM>>(user.Achievements.Take(6));

            return vm;
        }
    }
}
