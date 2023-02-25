using MediatR;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetAllVideos
{
    public class GetAllVideosQuery : IRequest<IEnumerable<GetAllVideosVm>>
    {
    }
}
