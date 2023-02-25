using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.DTOs.SubscribtionAPI
{
    public class ResponseSubFlowDTO
    {
        public ResponseSubService service { get; set; }
    }

    public class ResponseSubService
    {
        public string status { get; set; }
        public string rescode { get; set; }
        public string resdescription { get; set; }
        public string serviceid { get; set; }
    }
}
