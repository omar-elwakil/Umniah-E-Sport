using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentsByUserId
{
    public class GetTournamentsByUserIdQueryHandler : IRequestHandler<GetTournamentsByUserIdQuery, List<GetTournamentsByUserIdVm>>
    {
        private readonly IUserManager _userRepo;
        private readonly IMapper _mapper;

        public GetTournamentsByUserIdQueryHandler(IUserManager userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<List<GetTournamentsByUserIdVm>> Handle(GetTournamentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepo.GetAsync(request.UserId);
                var userTournaments = user.UserTournaments.Select(ut => ut.Tournament).ToList();
                var userTournamentsVm = _mapper.Map<List<GetTournamentsByUserIdVm>>(userTournaments);
                return userTournamentsVm;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
