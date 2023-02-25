using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.DTOs.SubscribtionFlowAPI
{
    public class ResponseCheckStatusDTO
    {
        public Response response { get; set; }
        public List<Service> services { get; set; }
    }

    public class Service
    {
        public string serviceid { get; set; }
        public string shortcode { get; set; }
        public string servicedesc { get; set; }
        public string state { get; set; }
        public string serviceprice { get; set; }
        public string serviceactdate { get; set; }
        public string nextrendate { get; set; }
        public string serdeactdate { get; set; }
        public string actchannel { get; set; }
        public string deactchannel { get; set; }
        public string servicetype { get; set; }
    }

    public class Response
    {
        public string status { get; set; }
        public string rescode { get; set; }
        public string resdescription { get; set; }
    }
}
