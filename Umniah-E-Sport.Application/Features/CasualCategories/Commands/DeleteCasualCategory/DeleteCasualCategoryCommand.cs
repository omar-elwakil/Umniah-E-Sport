using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualCategories.Commands.DeleteCasualCategory
{
    public class DeleteCasualCategoryCommand : IRequest<DeleteCasualCategoryResponse>
    {
        public int Id { get; set; }
    }
}
