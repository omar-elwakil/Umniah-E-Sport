using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdateUserProfileCommandResponse>
    {
        private readonly IUserManager _userRepo;

        public UpdateUserProfileCommandHandler(IUserManager userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UpdateUserProfileCommandResponse> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userRepo.GetByMSISDN(request.msisdn);

                if(user == null)
                {
                    return new UpdateUserProfileCommandResponse
                    {
                        Success = false,
                        Message = "User Not Found"
                    };
                }

                user.Name = request.name;

                var model = await _userRepo.UpdateAsync(user);
                return new UpdateUserProfileCommandResponse
                {
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {

                return new UpdateUserProfileCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
