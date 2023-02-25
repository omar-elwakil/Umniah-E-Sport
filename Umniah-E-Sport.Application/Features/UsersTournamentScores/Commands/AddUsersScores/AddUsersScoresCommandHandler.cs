using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.UserTournament.Commands.AddUsersScores
{
    public class AddUsersScoresCommandHandler : IRequestHandler<AddUsersScoresCommand, AddUsersScoresCommandResponse>
    {

        private readonly IUsersTournamentScoresManager _usersTournamentScoresRepo;

        public AddUsersScoresCommandHandler(IUsersTournamentScoresManager usersTournamentScoresRepo)
        {
            _usersTournamentScoresRepo = usersTournamentScoresRepo;
        }

        public Task<AddUsersScoresCommandResponse> Handle(AddUsersScoresCommand request, CancellationToken cancellationToken)
        {
            var response = _usersTournamentScoresRepo.AddUsersTournamentScores(request.AddUsersScoresCommandList);

            if (response.Success)
            {
                return Task.FromResult(new AddUsersScoresCommandResponse { Success = true });
            }

            return Task.FromResult(new AddUsersScoresCommandResponse { Success = false, Message = response.Message });
        }
    }
}
