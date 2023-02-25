using Umniah_E_Sport.Domain.Entities;
using Umniah_E_Sport.Persistence;
using Umniah_E_Sport.Persistence.Repos;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class CasualCategoryRepo : BaseManager<CasualCategory>,ICasualCategoryManager
    {
        public CasualCategoryRepo(UmniahContext context) : base(context)
        {
        }
    }
}
