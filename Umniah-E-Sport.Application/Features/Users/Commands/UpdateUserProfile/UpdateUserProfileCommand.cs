using MediatR;

namespace Umniah_E_Sport.Application.Features.Users.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand : IRequest<UpdateUserProfileCommandResponse>
    {
        public string msisdn { get; set; }
        public string name { get; set; }
    }
}
