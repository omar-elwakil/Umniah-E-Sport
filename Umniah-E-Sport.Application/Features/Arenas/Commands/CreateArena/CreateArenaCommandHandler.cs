using AutoMapper;
using MediatR;

using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Arenas.Commands.CreateArena
{
    public class CreateArenaCommandHandler : IRequestHandler<CreateArenaCommand, CreateArenaCommandResponse>
    {
        private readonly IArenaManager _arenaManager;
        private readonly IMapper _mapper;

        public CreateArenaCommandHandler(IArenaManager arenaManager, IMapper mapper)
        {
            _arenaManager = arenaManager;
            _mapper = mapper;
        }

        public async Task<CreateArenaCommandResponse> Handle(CreateArenaCommand request, CancellationToken cancellationToken)
        {
            CreateArenaCommandResponse response = new CreateArenaCommandResponse();
            try
            {
                var arena = _mapper.Map<Arena>(request);
                if (arena == null)
                {
                    response.Success = false;
                    response.Message = "Null after mapping";
                    return response;
                }
                await _arenaManager.AddAsync(arena);
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }


        }
    }
}
