using MediatR;

namespace Umniah_E_Sport.Application.Features.Users.Queries.ValidateOTP
{
    public class ValidateOTPQuery : IRequest<ValidateOTPQueryReponse>
    {
        public string msisdn { get; set; }
        public string otp { get; set; }
        public string? email { get; set; }
        //public string otpId { get; set; }
    }
}
