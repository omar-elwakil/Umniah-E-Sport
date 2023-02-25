using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.UserTournament.Queries.IsAlreadyJoinTournamet
{
    public class IsAlreadyJoinTournametQueryHandler : IRequestHandler<IsAlreadyJoinTournametQuery, IsAlreadyJoinTournametVM>
    {
        private readonly IUserManager _userRepo;
        private readonly IUserTournamentManager _userTournamentRepo;
        private readonly ITournamentManager _tournamentRepo;

        public IsAlreadyJoinTournametQueryHandler(IUserManager userRepo, IUserTournamentManager userTournamentRepo, ITournamentManager tournamentRepo)
        {
            _userRepo = userRepo;
            _userTournamentRepo = userTournamentRepo;
            _tournamentRepo = tournamentRepo;
        }

        public async Task<IsAlreadyJoinTournametVM> Handle(IsAlreadyJoinTournametQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepo.GetByEmail(request.email);

            if(user == null)
            {
                return new IsAlreadyJoinTournametVM { Success = false, IsExist = false, Message = "User not found" };
            }


            var tournament = await _tournamentRepo.GetAsync(request.tournamentId);

            if(tournament == null)
            {
                return new IsAlreadyJoinTournametVM { Success = false, IsExist = false, Message = "Tournament not found" };
            }

            var userTournament = _userTournamentRepo.GetUserTournamentByUserIdAndTournamentId(user.Id, tournament.Id);
            if (userTournament != null && ((DateTime.Now < tournament.StartDate) || (tournament.StartDate < DateTime.Now
              && DateTime.Now < tournament.StartDate.Add(tournament.DurationTimeSpan))))
            {
                return new IsAlreadyJoinTournametVM { Success = true, IsExist = true };
            }

            return new IsAlreadyJoinTournametVM { Success = true, IsExist = false };
        }
    }
}
