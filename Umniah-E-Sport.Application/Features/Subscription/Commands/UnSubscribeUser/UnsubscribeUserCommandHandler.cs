using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Umniah_E_Sport.Application.Features.Users.Commands.UnsubscribeUser
{
    class UnsubscribeUserCommandHandler : IRequestHandler<UnsubscribeUserCommand, UnsubscribeUserCommandResponse>
    {
        private readonly IUserManager _userRepo;
        private readonly ISubscriptionManager _subscriptionRepo;
        private readonly IMapper _mapper;

        public UnsubscribeUserCommandHandler(IUserManager userRepo, IMapper mapper, ISubscriptionManager subscriptionRepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _subscriptionRepo = subscriptionRepo;
        }

        public async Task<UnsubscribeUserCommandResponse> Handle(UnsubscribeUserCommand request, CancellationToken cancellationToken)
        {
            var response = _subscriptionRepo.UnSubscribeUser(request.msisdn);
            var result = _mapper.Map<UnsubscribeUserCommandResponse>(response);

            if (result.Success)
            {
                try
                {
                    var user = _userRepo.GetByMSISDN(request.msisdn);
                    if (user != null)
                    {
                        user.IsSubscribe = false;
                        user.UnsubscribeTimeStamp = DateTime.Now;
                        await _userRepo.UpdateAsync(user);
                    }
                }
                catch (Exception ex)
                {

                    result.Success = false;
                    result.Message = ex.Message;
                }

            }

            return result;
        }
    }
}
