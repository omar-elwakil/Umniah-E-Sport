using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Queries.IsUserAbleToSeeContent
{
    public class IsUserAbleToSeeContentQueryHandler : IRequestHandler<IsUserAbleToSeeContentQuery, bool>
    {
        private readonly IUserManager _userRepo;

        public IsUserAbleToSeeContentQueryHandler(IUserManager userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<bool> Handle(IsUserAbleToSeeContentQuery request, CancellationToken cancellationToken)
        {

            var user = _userRepo.GetByMSISDN(request.MSISDN);
            if (user == null) return Task.FromResult(false);
            if (user.IsSubscribe)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
