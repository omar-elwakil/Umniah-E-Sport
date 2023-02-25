using MediatR;

namespace Umniah_E_Sport.Application.Features.Users.Commands.RegisteredUserTournments
{
    public class RegisteredUserTournmentsCommand : IRequest<RegisteredUserTournmentsCommandResponse>
    {
        public string msisdn { get; set; }
        public string userName { get; set; }
        public int tournamentId { get; set; }
        public string ingameId { get; set; }
        public string email { get; set; }
    }
}
