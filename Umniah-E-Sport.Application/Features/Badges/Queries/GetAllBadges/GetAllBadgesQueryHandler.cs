using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Badges.Queries.GetAllBadges
{
    public class GetAllBadgesQueryHandler : IRequestHandler<GetAllBadgesQuery, List<GetAllBadgesVm>>
    {
        private readonly IBadgeManager _badgeManager;
        private readonly IMapper _mapper;

        public GetAllBadgesQueryHandler(IBadgeManager badgeManager, IMapper mapper)
        {
            _badgeManager = badgeManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllBadgesVm>> Handle(GetAllBadgesQuery request, CancellationToken cancellationToken)
        {
            var badges = await _badgeManager.GetAllAsync();
            var badgesVm = _mapper.Map<List<GetAllBadgesVm>>(badges);
            return badgesVm;
        }
    }
}
