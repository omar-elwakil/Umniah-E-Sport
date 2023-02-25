using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;


namespace Umniah_E_Sport.Application.Features.Users.Queries.ValidateOTP
{
    public class ValidateOTPQueryHandler : IRequestHandler<ValidateOTPQuery, ValidateOTPQueryReponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionManager _subscriptionRepo;

        public ValidateOTPQueryHandler(IMapper mapper, ISubscriptionManager subscriptionRepo)
        {
            _mapper = mapper;
            _subscriptionRepo = subscriptionRepo;
        }
        public async Task<ValidateOTPQueryReponse> Handle(ValidateOTPQuery request, CancellationToken cancellationToken)
        {
            var validateOTP = await _subscriptionRepo.ValidateOTP(request.msisdn, request.otp);
            var result = _mapper.Map<ValidateOTPQueryReponse>(validateOTP);
            return result;
        }
    }
}
