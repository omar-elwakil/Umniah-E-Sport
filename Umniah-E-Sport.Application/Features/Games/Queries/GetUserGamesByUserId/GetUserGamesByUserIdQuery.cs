using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetUserGamesByUserId
{
    public class GetUserGamesByUserIdQuery : IRequest<List<GetUserGamesByUserIdVm>>
    {
        public int Id { get; set; }
    }
}
