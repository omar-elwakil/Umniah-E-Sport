using MediatR;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.Videos.Commands.AddVideoToGame;
using Umniah_E_Sport.Application.Features.Videos.Commands.DeleteVideoById;
using Umniah_E_Sport.Application.Features.Videos.Commands.UpdateVideoById;
using Umniah_E_Sport.Application.Features.Videos.Queries.CheckIfVideoExist;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetAllVideos;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetLatestVideos;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetRelatedVideos;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetVideoById;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetVideosByGame;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IMediator _mediator;

        private const int LATEST_VIDEOS_COUNT = 4;
        public VideosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-videos")]
        public async Task<IEnumerable<GetAllVideosVm>> GetAllVideosAsync()
        {
            var videos = await _mediator.Send(new GetAllVideosQuery());
            return videos;
        }
        [HttpGet("related-videos")]
        public async Task<IEnumerable<GetRelatedVideosVm>> GetRelatedVideosAsync([FromQuery] GetRelatedVideosQuery getRelatedVideosQuery)
        {
            var videos = await _mediator.Send(getRelatedVideosQuery);
            return videos;
        }
        [HttpGet("latest-videos")]
        public async Task<IEnumerable<GetLatestVideosVm>> GetLatestVideosAsync()
        {
            var videos = await _mediator.Send(new GetLatestVideosQuery { VideosCount = LATEST_VIDEOS_COUNT });
            return videos;
        }
        [HttpGet("video-details")]
        public async Task<GetVideoByIdVm> GetVideoDetailsAsync([FromQuery] GetVideoByIdQuery getVideoByIdQuery)
        {
            var video = await _mediator.Send(getVideoByIdQuery);
            if (video == null)
                return null;
            return video;
        }
        [HttpGet("videos-by-game")]
        public async Task<IEnumerable<GetVideosByGameVm>> GetVideosByGameAsync([FromQuery] GetVideosByGameQuery getVideosByGameQuery)
        {
            var videos = await _mediator.Send(getVideosByGameQuery);
            return videos;
        }
        [HttpPost("add-videos-to-game")]
        public async Task<AddVideoToGameVm> AddVideoToGame([FromBody] AddVideoToGameCommand addVideoToGameCommand)
        {
            var response = await _mediator.Send(addVideoToGameCommand);
            return response;
        }
        [HttpPut("update-video-by-id")]
        public async Task<UpdateVideoByIdVm> UpdateVideoById([FromBody] UpdateVideoByIdCommand updateVideoByIdCommand)
        {
            var response = await _mediator.Send(updateVideoByIdCommand);
            return response;
        }
        [HttpDelete("delete-video-by-id")]
        public async Task<DeleteVideoByIdVm> DeleteVideoById([FromQuery] DeleteVideoByIdCommand deleteVideoByIdCommand)
        {
            var response = await _mediator.Send(deleteVideoByIdCommand);
            return response;
        }
        [HttpGet("check-if-video-exist")]
        public async Task<CheckIfVideoExistVm> CheckIfVideoIsExist([FromQuery] CheckIfVideoExistQuery checkIfVideoExistQuery)
        {
            var response = await _mediator.Send(checkIfVideoExistQuery);
            return response;
        }
    }
}