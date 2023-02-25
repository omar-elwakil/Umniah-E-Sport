using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Users.Queries.SendSMSContent
{
    public class SendSMSContentHandler : IRequestHandler<SendSMSContent, SendSMSContentResponse>
    {
        private readonly ISubscriptionManager _subscriptionRepo;
        private readonly IMapper _mapper;

        public SendSMSContentHandler(ISubscriptionManager subscriptionRepo, IMapper mapper)
        {
            _subscriptionRepo = subscriptionRepo;
            _mapper = mapper;
        }

        public async Task<SendSMSContentResponse> Handle(SendSMSContent request, CancellationToken cancellationToken)
        {
            var response = _subscriptionRepo.SendSMS(request.MSISDN, request.SmsContent);
            var result = _mapper.Map<SendSMSContentResponse>(response);
            return await Task.FromResult(result);
        }
    }
}
