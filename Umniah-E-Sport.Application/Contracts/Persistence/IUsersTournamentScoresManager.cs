using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Features.UserTournament.Commands.AddUsersScores;
using Umniah_E_Sport.Application.Responses;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface IUsersTournamentScoresManager
    {
        public BaseResponse AddUsersTournamentScores(List<AddUsersScoresCommandItem> addUsersScoresCommandItems);
    }
}
