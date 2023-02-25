using MediatR;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetGame
{
    public class GetGameQuery : IRequest<GetGameVM>
    {
        public int Id { get; set; }
    }
}
