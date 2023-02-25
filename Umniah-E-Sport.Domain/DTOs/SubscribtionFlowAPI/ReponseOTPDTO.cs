using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.DTOs.SubscribtionFlowAPI
{
    public class ManagernseOTPDTO
    {
        public ResponseGenOTP response { get; set; }
    }

    public class ResponseGenOTP
    {
        public string status { get; set; }
        public string rescode { get; set; }
        public string resdescription { get; set; }
        public string otpid { get; set; }
    }
}
