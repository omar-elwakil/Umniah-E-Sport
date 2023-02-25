using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.DTOs.SubscribtionAPI
{
    public class RequestSubDTO
    {
        public RequestService service { get; set; }
    }

    public class RequestService
    {
        public string reqtype { get; set; }
        public string msisdn { get; set; }
        public string serviceid { get; set; }
        public string chnl { get; set; }
        public string scode { get; set; }
        public string otpid { get; set; }
    }
}
