using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.DTOs.SubscribtionFlowAPI
{
    public class RequestCheckStatusDTO
    {
        public string reqtype { get; set; }
        public string msisdn { get; set; }
        public string serviceid { get; set; }
        public string status { get; set; }
        public string scode { get; set; }
    }
}
