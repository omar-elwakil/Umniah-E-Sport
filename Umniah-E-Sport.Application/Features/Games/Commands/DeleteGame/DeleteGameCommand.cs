using MediatR;

namespace Umniah_E_Sport.Application.Features.Games.Commands.DeleteGame
{
    public class DeleteGameCommand : IRequest<DeleteGameCommandResponse>
    {
        public int id { get; set; }
    }
}
