using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGames.Queries.GetCasualGamesByCategoryId
{
    public class GetCasualGamesByCategoryIdQuery : IRequest<List<GetCasualGamesByCategoryIdVm>>
    {
        public int CategoryId { get; set; }
    }
}
