
using Umniah_E_Sport.Application.Features.Users.Queries.GenerateOTP;
using Umniah_E_Sport.Application.Responses;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface ISubscriptionManager
    {
        public Task<GenerateOTPQueryResponse> GenerateOTP(string msisdn);
        public Task<BaseResponse> ValidateOTP (string msisdn, string otp);
        public BaseResponse UnSubscribeUser(string msisdn);
        public BaseResponse SendSMS(string msisdn, bool isSMSSubscription);
        public BaseResponse SendSMS(string msisdn, string content);

    }
}
