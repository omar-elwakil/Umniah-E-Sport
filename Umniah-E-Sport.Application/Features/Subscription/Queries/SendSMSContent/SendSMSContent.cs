using MediatR;

namespace Umniah_E_Sport.Application.Features.Users.Queries.SendSMSContent
{
    public class SendSMSContent : IRequest<SendSMSContentResponse>
    {
        public string MSISDN { get; set; }
        public string SmsContent { get; set; }
    }
}
