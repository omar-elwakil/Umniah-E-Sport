using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.News.Commands.DeleteNews
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, DeleteNewsCommandResponse>
    {
        private readonly INewsManager _newsRepo;

        public DeleteNewsCommandHandler(INewsManager newsRepo)
        {
            _newsRepo = newsRepo;
        }

        public async Task<DeleteNewsCommandResponse> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsRepo.GetAsync(request.Id);
            if (news == null) { return new DeleteNewsCommandResponse { Message = "Not Found", Success = false }; }
            news.IsDeleted = true;
            await _newsRepo.UpdateAsync(news);
            return new DeleteNewsCommandResponse { Success = true };
        }
    }
}
