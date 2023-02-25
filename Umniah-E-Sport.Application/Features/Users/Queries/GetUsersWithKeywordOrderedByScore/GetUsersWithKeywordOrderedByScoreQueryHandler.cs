using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUsersWithKeywordOrderedByScore
{
    public class GetUsersWithKeywordOrderedByScoreQueryHandler : IRequestHandler<GetUsersWithKeywordOrderedByScoreQuery, List<GetUsersWithKeywordOrderedByScoreVm>>
    {
        private readonly IUserManager _userRepo;
        private readonly IMapper _mapper;

        public GetUsersWithKeywordOrderedByScoreQueryHandler(IUserManager userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public Task<List<GetUsersWithKeywordOrderedByScoreVm>> Handle(GetUsersWithKeywordOrderedByScoreQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepo.GetUsersBySearchKeyword(request.Keyword).OrderByDescending(u => u.Score);
            var usersVm = _mapper.Map<List<GetUsersWithKeywordOrderedByScoreVm>>(users);
            return Task.FromResult(usersVm);
        }
    }
}
