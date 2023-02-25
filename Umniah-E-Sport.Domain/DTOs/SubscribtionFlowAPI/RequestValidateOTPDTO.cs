using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.DTOs.SubscribtionFlowAPI
{
    public class RequestValidateOTPDTO
    {
        public string reqtype { get; set; }
        public string msisdn { get; set; }
        public string otpid { get; set; }
        public string otp { get; set; }
    }
}
