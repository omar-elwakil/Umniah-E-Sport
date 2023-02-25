using MediatR;

namespace Umniah_E_Sport.Application.Features.Users.Queries.SendSMS
{
    public class SendSMSQuery : IRequest<SendSMSQueryResponse>
    {
        public string MSISDN { get; set; }
        public bool IsSMSSubscribe { get; set; }
    }
}
