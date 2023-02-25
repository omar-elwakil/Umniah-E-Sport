
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.API.Models;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Features.Users.Queries.GenerateOTP;
using Umniah_E_Sport.Application.Features.Users.Queries.ValidateOTP;
using Umniah_E_Sport.Application.Features.Users.Commands.UpdateUserStatus;
using Umniah_E_Sport.Application.Features.Users.Queries.SendSMS;
using Umniah_E_Sport.Application.Features.Users.Queries.SendSMSContent;
using Umniah_E_Sport.Application.Features.Users.Commands.SubscribeUser;
using Umniah_E_Sport.Application.Features.Users.Commands.SubscribeUserMail;
using Umniah_E_Sport.Application.Features.Users.Commands.UnsubscribeUser;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("get-otp")]
        public async Task<GenerateOTPQueryResponse> GetOtp([FromBody] GenerateOTPQuery generateOTPQuery)
        {
            var response = await _mediator.Send(generateOTPQuery);
            return response;
        }

        [HttpPost("subscribe-user")]
        public async Task<ValidateOTPQueryReponse> SubscribeUser([FromBody] ValidateOTPQuery validateOTPQuery)
        {
            var validateOTPResponse = await _mediator.Send(validateOTPQuery);

            if (validateOTPResponse.Success)
            {
                var response = await _mediator.Send(new SubscribeUserCommand
                {
                    msisdn = validateOTPQuery.msisdn,
                    otp = validateOTPQuery.otp,
                    mail = validateOTPQuery.email
                });
                return new ValidateOTPQueryReponse { Success = response.Success, Message = response.Message };
            }
            return validateOTPResponse;
        }

        [HttpPost("subscribe-user-mail")]
        public async Task<ValidateOTPQueryReponse> SubscribeUserMail([FromBody] UserMailDTO userMailDTO)
        {
            var response = await _mediator.Send(new SubscribeUserMailCommand
            {
                msisdn = userMailDTO.msisdn,
                mail = userMailDTO.email
            });
            return new ValidateOTPQueryReponse { Success = response.Success, Message = response.Message };
        }

        [HttpPost("unsubscribe-user")]
        public async Task<UnsubscribeUserCommandResponse> UnsubscribeUser([FromBody] UnsubscribeUserCommand query)
        {
            var unSubResponse = await _mediator.Send(new UnsubscribeUserCommand { msisdn = query.msisdn });
            return unSubResponse;
        }

        [HttpGet("data-sync")]
        public async Task<string> UpdateUserStatus([FromQuery] UpdateUserStatusCommand command)
        {
            return (await _mediator.Send(command)).Message;
        }
        [HttpGet("send-sms")]
        public async Task<SendSMSQueryResponse> SendSMS([FromQuery] SendSMSQuery sendSMSQuery)
        {
            return await _mediator.Send(sendSMSQuery);
        }

        [HttpGet("send-sms-content")]
        public async Task<SendSMSContentResponse> SendSMSContent([FromQuery] SendSMSContent sendSMSContent)
        {
            return await _mediator.Send(sendSMSContent);
        }
    }
}
