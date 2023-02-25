using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.DeleteTournamentType
{
    public class DeleteTournamentTypeCommand : IRequest<DeleteTournamentTypeCommandResponse>
    {
        public int Id { get; set; }
    }
}
