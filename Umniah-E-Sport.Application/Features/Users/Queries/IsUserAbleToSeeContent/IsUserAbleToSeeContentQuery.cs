using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Users.Queries.IsUserAbleToSeeContent
{
    public class IsUserAbleToSeeContentQuery : IRequest<bool>
    {
        public string MSISDN { get; set; }
    }
}
