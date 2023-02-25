using MediatR;

namespace Umniah_E_Sport.Application.Features.Users.Commands.SubscribeUserMail
{
    public class SubscribeUserMailCommand : IRequest<SubscribeUserMailCommandResponse>
    {
        public string? msisdn { get; set; }
        public string mail { get; set; }
    }
}
