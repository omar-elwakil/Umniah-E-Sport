using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualCategories.Queries.GetAllCasualCategories
{
    public class GetAllCasualCategoriesQuery : IRequest<List<GetAllCasualCategoriesVm>>
    {
    }
}
