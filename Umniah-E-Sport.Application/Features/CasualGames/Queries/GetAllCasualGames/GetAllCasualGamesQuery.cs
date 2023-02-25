using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGames.Queries.GetAllCasualGames
{
    public class GetAllCasualGamesQuery : IRequest<List<GetAllCasualGamesVm>>
    {
    }
}
