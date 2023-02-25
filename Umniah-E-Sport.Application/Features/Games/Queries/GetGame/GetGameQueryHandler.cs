using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetGame
{
    public class GetGameQueryHandler : IRequestHandler<GetGameQuery, GetGameVM>
    {
        private readonly IGameManager _gameManager;
        private readonly IMapper _mapper;

        public GetGameQueryHandler(IGameManager gameManager, IMapper mapper)
        {
            _gameManager = gameManager;
            _mapper = mapper;
        }

        public async Task<GetGameVM> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var game = await _gameManager.GetAsync(request.Id);
                if(game != null)
                {
                    var model = _mapper.Map<GetGameVM>(game);
                    model.IsExist = true;
                    return model;
                }

                return new GetGameVM { Success = true, Message = "Game Not Found", IsExist = false};
            }
            catch (Exception ex)
            {
                return new GetGameVM { Success = false, Message = ex.InnerException.Message };
            }
        }
    }
}
