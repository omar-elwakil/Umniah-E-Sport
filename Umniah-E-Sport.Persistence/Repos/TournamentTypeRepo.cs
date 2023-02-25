using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class TournamentTypeRepo : BaseManager<TournamentType>,ITournamentTypeManager
    {
        public TournamentTypeRepo(UmniahContext context) : base(context)
        {
        }
    }
}
