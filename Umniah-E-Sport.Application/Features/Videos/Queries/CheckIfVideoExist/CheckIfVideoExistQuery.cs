using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.CheckIfVideoExist
{
    public class CheckIfVideoExistQuery : IRequest<CheckIfVideoExistVm>
    {
        public int Id { get; set; }
    }
}
