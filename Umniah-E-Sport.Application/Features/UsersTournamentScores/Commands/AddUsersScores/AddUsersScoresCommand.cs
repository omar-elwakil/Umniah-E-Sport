using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.UserTournament.Commands.AddUsersScores
{
    public class AddUsersScoresCommand : IRequest<AddUsersScoresCommandResponse>
    {
        public List<AddUsersScoresCommandItem> AddUsersScoresCommandList { get; set; }
    }
}
