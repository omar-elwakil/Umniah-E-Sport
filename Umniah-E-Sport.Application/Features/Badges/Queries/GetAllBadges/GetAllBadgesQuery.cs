using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Badges.Queries.GetAllBadges
{
    public class GetAllBadgesQuery : IRequest<List<GetAllBadgesVm>>
    {
    }
}
