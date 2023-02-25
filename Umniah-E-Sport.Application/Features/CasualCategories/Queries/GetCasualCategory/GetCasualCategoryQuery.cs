using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualCategories.Queries.GetCasualCategory
{
    public class GetCasualCategoryQuery : IRequest<GetCasualCategoryVm>
    {
        public int Id { get; set; }
    }
}
