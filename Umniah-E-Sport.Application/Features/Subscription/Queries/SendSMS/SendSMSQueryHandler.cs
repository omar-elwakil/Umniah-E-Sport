using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Users.Queries.SendSMS
{
    public class SendSMSQueryHandler : IRequestHandler<SendSMSQuery, SendSMSQueryResponse>
    {
        private readonly ISubscriptionManager _subscriptionRepo;
        private readonly IMapper _mapper;

        public SendSMSQueryHandler(ISubscriptionManager subscriptionRepo, IMapper mapper)
        {
            _subscriptionRepo = subscriptionRepo;
            _mapper = mapper;
        }

        public async Task<SendSMSQueryResponse> Handle(SendSMSQuery request, CancellationToken cancellationToken)
        {
            var response = _subscriptionRepo.SendSMS(request.MSISDN, request.IsSMSSubscribe);
            var result = _mapper.Map<SendSMSQueryResponse>(response);
            return await Task.FromResult(result);
        }
    }
}
