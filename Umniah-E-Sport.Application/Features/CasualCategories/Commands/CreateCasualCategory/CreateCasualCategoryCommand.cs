using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualCategories.Commands.CreateCasualCategory
{
    public class CreateCasualCategoryCommand : IRequest<CreateCasualCategoryResponse>
    {
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string ImageName { get; set; }
    }
}
