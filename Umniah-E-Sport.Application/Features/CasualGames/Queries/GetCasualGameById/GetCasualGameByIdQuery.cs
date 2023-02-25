using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGames.Queries.GetCasualGameById
{
    public class GetCasualGameByIdQuery : IRequest<GetCasualGameByIdVm>
    {
        public int Id { get; set; }
    }
}
