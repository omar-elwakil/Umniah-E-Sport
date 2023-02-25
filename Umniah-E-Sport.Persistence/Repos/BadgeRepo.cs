using Umniah_E_Sport.Application.Contracts.Persistence;

using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class BadgeRepo : BaseManager<Badge>, IBadgeManager
    {
        public BadgeRepo(UmniahContext context) : base(context)
        {
        }
    }
}
