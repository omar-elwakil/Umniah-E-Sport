using MediatR;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GenerateOTP
{
    public class GenerateOTPQuery : IRequest<GenerateOTPQueryResponse>
    {
        public string MSISDN { get; set; }
    }
}
