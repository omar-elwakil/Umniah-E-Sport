using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Commands.RegisteredUserTournments
{
    public class RegisteredUserTournmentsCommandHandler : IRequestHandler<RegisteredUserTournmentsCommand, RegisteredUserTournmentsCommandResponse>
    {
        private readonly IUserManager _userRepo;
        private readonly ITournamentManager _tournamentRepo;
        private readonly IUserTournamentManager _userTournamentRepo;
        private readonly IUserGameManager _userGameRepo;
        private readonly IMapper _mapper;

        public RegisteredUserTournmentsCommandHandler(
            IUserManager userRepo,
            IMapper mapper,
            IUserTournamentManager userTournamentRepo,
            ITournamentManager tournamentRepo, IUserGameManager userGameRepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userTournamentRepo = userTournamentRepo;
            _tournamentRepo = tournamentRepo;
            _userGameRepo = userGameRepo;
        }

        public async Task<RegisteredUserTournmentsCommandResponse> Handle(RegisteredUserTournmentsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userRepo.GetByMSISDN(request.msisdn);
                if (user == null)
                {
                    user = _userRepo.GetByEmail(request.email);
                }

                if (user == null)
                {
                    return new RegisteredUserTournmentsCommandResponse { Success = false, Message = "User Not Found" };
                }

                var tournament = await _tournamentRepo.GetAsync(request.tournamentId);
                if (tournament == null)
                {
                    return new RegisteredUserTournmentsCommandResponse { Success = false, Message = "Tournament Not Found" };
                }

                var userTournament = _userTournamentRepo.GetUserTournamentByUserIdAndTournamentId(user.Id, request.tournamentId);
                if (userTournament != null)
                {
                    return new RegisteredUserTournmentsCommandResponse { Success = false, Message = "User already join" };
                }

                var userGame = await _userGameRepo.GetUsersGames(tournament.GameId, user.Id);
                if (userGame == null)
                {
                    await _userGameRepo.AddAsync(new UserGames { GameId = tournament.GameId, UserId = user.Id, UserScore = 0 });
                }

                await _userTournamentRepo.AddAsync(
                    new UserTournaments
                    {
                        TimeStamp = DateTime.Now,
                        UserId = user.Id,
                        TournamentId = tournament.Id,
                        UserName = request.userName,
                        IngameId = request.ingameId,
                        IsTheFirst = false,
                        IsDailySmsSent = false,
                        IsHourlySmsSent = false,
                        IsJoinSmsSent = false
                    });
                user.Score += 100;
                await _userRepo.UpdateAsync(user);

                _userRepo.WelcomeBadge(user.Msisdn);
                _userRepo.EarlyBadge(user.Msisdn, tournament.Id);
                _userRepo.ActiveBadge(user.Msisdn);


                return new RegisteredUserTournmentsCommandResponse { Success = true };
            }
            catch (Exception ex)
            {
                return new RegisteredUserTournmentsCommandResponse { Success = false, Message = ex.InnerException.Message };
            }
        }
    }
}
