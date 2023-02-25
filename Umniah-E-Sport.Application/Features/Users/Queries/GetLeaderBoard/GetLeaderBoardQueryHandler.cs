using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetLeaderBoard
{
    public class GetLeaderBoardQueryHandler : IRequestHandler<GetLeaderBoardQuery, List<GetLeaderBoardVM>>
    {
        private readonly IUserManager _userRepo;
        private readonly IMapper _mapper;

        public GetLeaderBoardQueryHandler(IUserManager userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<List<GetLeaderBoardVM>> Handle(GetLeaderBoardQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepo.GetLeaderBoard();

            return _mapper.Map<List<GetLeaderBoardVM>>(result);
        }
    }
}