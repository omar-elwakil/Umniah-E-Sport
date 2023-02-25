using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Commands.SubscribeUser
{
    class SubscribeUserCommandHandler : IRequestHandler<SubscribeUserCommand, SubscribeUserCommandResponse>
    {
        private readonly IUserManager _userRepo;

        public SubscribeUserCommandHandler(IUserManager userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<SubscribeUserCommandResponse> Handle(SubscribeUserCommand request, CancellationToken cancellationToken)
        {
            var userCheck = _userRepo.GetByMSISDN(request.msisdn);
            var userbyMail = _userRepo.GetByEmail(request.mail);
            if (userCheck == null && userbyMail == null)
            {
                var user = new User
                {
                    Msisdn = request.msisdn,
                    CreationTimeStamp = DateTime.Now,
                    SubscribeTimeStamp = DateTime.Now,
                    Email = request.mail,
                    IsSubscribe = true,
                    Name = "Subscribe_" + request.msisdn
                };
                await _userRepo.AddAsync(user);
                return new SubscribeUserCommandResponse { Success = true, Message = "Successful" };
            }
            else if (userCheck == null && userbyMail != null)
            {
                userbyMail.Msisdn = request.msisdn;
                userbyMail.IsSubscribe = true;
                userbyMail.SubscribeTimeStamp = DateTime.Now;
                await _userRepo.UpdateAsync(userbyMail);
                return new SubscribeUserCommandResponse { Success = true, Message = "Show Content to the User" };
            }
            else if (userCheck != null)
            {
                userCheck.IsSubscribe = true;
                userCheck.SubscribeTimeStamp = DateTime.Now;
                userCheck.UnsubscribeTimeStamp = null;
                await _userRepo.UpdateAsync(userCheck);
                return new SubscribeUserCommandResponse { Success = true, Message = "Show Content to the User" };
            }
            return new SubscribeUserCommandResponse { Success = true, Message = "Show Content to the User" };
        }
    }
}
