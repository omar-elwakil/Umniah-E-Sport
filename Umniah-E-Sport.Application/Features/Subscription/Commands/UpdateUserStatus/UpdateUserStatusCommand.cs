using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Users.Commands.UpdateUserStatus
{
    public class UpdateUserStatusCommand : IRequest<UpdateUserStatusCommandResponse>
    {

        public string username { get; set; }
        public string password { get; set; }
        public string msisdn { get; set; }
        public int actionType { get; set; }
        public string serviceId { get; set; }
        public string spId { get; set; }
        public string date { get; set; }
        public string requestid { get; set; }
        public string sc { get; set; }
        public string key { get; set; }
    }
}
