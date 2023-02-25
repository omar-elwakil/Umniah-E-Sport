using MediatR;

namespace Umniah_E_Sport.Application.Features.Users.Commands.SubscribeUser
{
    public class SubscribeUserCommand : IRequest<SubscribeUserCommandResponse>
    {
        public string msisdn { get; set; }
        public string otp { get; set; }
        public string? mail { get; set; }
    }
}
