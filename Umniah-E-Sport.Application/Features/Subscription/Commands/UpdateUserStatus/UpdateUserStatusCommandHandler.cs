using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Features.Users.Commands.UpdateUserStatus
{
    public class UpdateUserStatusCommandHandler : IRequestHandler<UpdateUserStatusCommand, UpdateUserStatusCommandResponse>
    {
        private readonly IUserManager _userRepo;
        private readonly INotificationLogManager _notificationLogRepo;

        public UpdateUserStatusCommandHandler(IUserManager userRepo, INotificationLogManager notificationLogRepo)
        {
            _userRepo = userRepo;
            _notificationLogRepo = notificationLogRepo;
        }

        public async Task<UpdateUserStatusCommandResponse> Handle(UpdateUserStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userRepo.GetByMSISDN(request.msisdn);
                if (user == null)
                {
                    user = new User
                    {
                        CreationTimeStamp = DateTime.Now,
                        Msisdn = request.msisdn
                    };
                    await _userRepo.AddAsync(user);
                }
                if ((SubscriptionActionType)request.actionType == SubscriptionActionType.Subscibe)
                {
                    user.IsSubscribe = true;
                    user.SubscribeTimeStamp = DateTime.Now;
                }
                else if ((SubscriptionActionType)request.actionType == SubscriptionActionType.Unsunscribe)
                {
                    user.IsSubscribe = false;
                    user.UnsubscribeTimeStamp = DateTime.Now;
                }
                else if ((SubscriptionActionType)request.actionType == SubscriptionActionType.Billing)
                {
                    user.IsSubscribe = true;
                }
                else if ((SubscriptionActionType)request.actionType == SubscriptionActionType.Failed)
                {
                    user.IsSubscribe = false;
                }
                else
                {
                    await _notificationLogRepo.AddAsync(new NotificationLog { MSISDN = request.msisdn, ActionType = request.actionType, CreationTimeStamp = DateTime.Now, Response = "Action type is not exist" });
                    return new UpdateUserStatusCommandResponse { Success = false, Message = "Action type is not exist" };
                }
                await _userRepo.UpdateAsync(user);
                await _notificationLogRepo.AddAsync(new NotificationLog { MSISDN = request.msisdn, ActionType = request.actionType, CreationTimeStamp = DateTime.Now , Response="OK"});
                return new UpdateUserStatusCommandResponse { Success = true, Message = "OK" };
            }
            catch (Exception ex)
            {
                await _notificationLogRepo.AddAsync(new NotificationLog { MSISDN = request.msisdn, ActionType = request.actionType, CreationTimeStamp = DateTime.Now, Response = ex.Message });
                return new UpdateUserStatusCommandResponse { Success = false, Message = ex.Message };
            }
        }
    }
}