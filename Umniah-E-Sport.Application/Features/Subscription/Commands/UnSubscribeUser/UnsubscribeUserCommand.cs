using MediatR;

namespace Umniah_E_Sport.Application.Features.Users.Commands.UnsubscribeUser
{
    public class UnsubscribeUserCommand : IRequest<UnsubscribeUserCommandResponse>
    {
        public string msisdn { get; set; }
    }
}
