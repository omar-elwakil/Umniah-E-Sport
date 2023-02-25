using MediatR;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.News.Commands.CreateNews;
using Umniah_E_Sport.Application.Features.News.Commands.DeleteNews;
using Umniah_E_Sport.Application.Features.News.Commands.UpdateNews;
using Umniah_E_Sport.Application.Features.News.Quereis.GetAllNews;
using Umniah_E_Sport.Application.Features.News.Quereis.GetLatestNews;
using Umniah_E_Sport.Application.Features.News.Quereis.GetNews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-news")]
        public async Task<ActionResult<List<NewsCardVM>>> GetAllNewsAsync()
        {
            var allNews = await _mediator.Send(new GetAllNewsQuery());
            return Ok(allNews);
        }


        [HttpGet("get-latest-news")]
        public async Task<ActionResult<List<LatestNewsCardVM>>> GetLatestNewsAsync([FromQuery] GetLatestNewsQuery getLatestNewsQuery)
        {
            var allNews = await _mediator.Send(getLatestNewsQuery);
            return Ok(allNews);
        }

        [HttpGet("get-news")]
        public async Task<ActionResult<NewsCardDetailVM>> GetNewsAsync([FromQuery] GetNewsQuery getNewsQuery)
        {
            var allNews = await _mediator.Send(getNewsQuery);

            if (allNews != null)
            {
                return Ok(allNews);
            }
            return NotFound();
        }

        [HttpPost("create-news")]
        public async Task<ActionResult<CreateNewsCommandResponse>> CreateNews([FromBody] CreateNewsCommand createNewsCommand)
        {
            return await _mediator.Send(createNewsCommand);
        }

        [HttpPut("update-news")]
        public async Task<ActionResult<UpdateNewsCommandResponse>> UpdateNews([FromBody] UpdateNewsCommand updateNewsCommand)
        {
            return await _mediator.Send(updateNewsCommand);
        }

        [HttpDelete("delete-news")]
        public async Task<ActionResult<DeleteNewsCommandResponse>> DeleteNews(DeleteNewsCommand deleteNewsCommand)
        {
            return await _mediator.Send(deleteNewsCommand);
        }
    }
}
