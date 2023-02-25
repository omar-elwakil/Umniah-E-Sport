using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetVideosByGame
{
    public class GetVideosByGameQuery : IRequest<IEnumerable<GetVideosByGameVm>>
    {
        public int GamedId { get; set; }
    }
}
