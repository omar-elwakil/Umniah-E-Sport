using Umniah_E_Sport.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Locations.Queries.GetLocationById
{
    public class GetLocationByIdVm : BaseResponse
    {
        public int Id { get; set; }
        public string Text_EN { get; set; }
        public string Text_AR { get; set; }
    }
}
