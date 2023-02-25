using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GenerateOTP
{
    public class GenerateOTPQueryHandler : IRequestHandler<GenerateOTPQuery, GenerateOTPQueryResponse>
    {
        private readonly ISubscriptionManager _subscriptionRepo;

        public GenerateOTPQueryHandler(ISubscriptionManager subscriptionRepo)
        {
            _subscriptionRepo = subscriptionRepo;
        }

        public async Task<GenerateOTPQueryResponse> Handle(GenerateOTPQuery request, CancellationToken cancellationToken)
        {
            var otp = await _subscriptionRepo.GenerateOTP(request.MSISDN);
            return otp;
        }
    }
}
