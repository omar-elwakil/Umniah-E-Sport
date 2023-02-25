using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<GetUserProfileVM>
    {
        public string MSISDN { get; set; }
    }
}
