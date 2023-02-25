using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.TournamentTypeFeature.Queries.GetTournamentTypeById
{
    public class GetTournamentTypeByIdQuery : IRequest<GetTournamentTypeByIdVm>
    {
        public int Id { get; set; }
    }
}
