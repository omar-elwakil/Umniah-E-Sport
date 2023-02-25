using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Commands.SubscribeUserMail
{
    class SubscribeUserMailCommandHandler : IRequestHandler<SubscribeUserMailCommand, SubscribeUserMailCommandResponse>
    {
        private readonly IUserManager _userRepo;

        public SubscribeUserMailCommandHandler(IUserManager userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<SubscribeUserMailCommandResponse> Handle(SubscribeUserMailCommand request, CancellationToken cancellationToken)
        {
            var userCheck = _userRepo.GetByMSISDN(request.msisdn);
            var userbyMail = _userRepo.GetByEmail(request.mail);
            
            if (userCheck == null && userbyMail == null)
            {
                var user = new User
                {
                    CreationTimeStamp = DateTime.Now,
                    Email = request.mail,
                    IsSubscribe = false,
                    Name = "UserName_" + request.mail,
                };
                await _userRepo.AddAsync(user);
                return new SubscribeUserMailCommandResponse { Success = true, Message = "Successful" };
            }
            else if (userCheck != null && userbyMail == null)
            {
                userCheck.Email = request.mail;
                await _userRepo.UpdateAsync(userCheck);
                return new SubscribeUserMailCommandResponse { Success = true, Message = "Successful" };
            }
            return new SubscribeUserMailCommandResponse { Success = true, Message = "Successful" };
        }
    }
}
