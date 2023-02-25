using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetAllUsersOrderedByScore
{
    public class GetAllUsersOrderedByScoreQuery : IRequest<List<GetAllUsersOrderedByScoreVm>>
    {
    }
}
