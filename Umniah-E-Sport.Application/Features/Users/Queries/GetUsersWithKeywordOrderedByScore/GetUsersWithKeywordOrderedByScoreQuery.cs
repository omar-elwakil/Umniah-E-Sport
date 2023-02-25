using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUsersWithKeywordOrderedByScore
{
    public class GetUsersWithKeywordOrderedByScoreQuery : IRequest<List<GetUsersWithKeywordOrderedByScoreVm>>
    {
        public string Keyword { get; set; }
    }
}
