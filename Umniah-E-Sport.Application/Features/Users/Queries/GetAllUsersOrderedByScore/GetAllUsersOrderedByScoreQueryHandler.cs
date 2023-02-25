using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetAllUsersOrderedByScore
{
    internal class GetAllUsersOrderedByScoreQueryHandler : IRequestHandler<GetAllUsersOrderedByScoreQuery, List<GetAllUsersOrderedByScoreVm>>
    {
        private readonly IUserManager _userRepo;
        private readonly IMapper _mapper;

        public GetAllUsersOrderedByScoreQueryHandler(IUserManager userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<List<GetAllUsersOrderedByScoreVm>> Handle(GetAllUsersOrderedByScoreQuery request, CancellationToken cancellationToken)
        {
            var users =(await _userRepo.GetAllAsync()).OrderByDescending(u => u.Score);
            var usersVm = _mapper.Map<List<GetAllUsersOrderedByScoreVm>>(users);
            return usersVm;
        }
    }
}
