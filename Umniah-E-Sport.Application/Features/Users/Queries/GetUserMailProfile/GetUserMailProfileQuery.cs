using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUserMailProfile
{
    public class GetUserMailProfileQuery : IRequest<GetUserMailProfileVM>
    {
        public string MSISDN { get; set; }
    }
}
