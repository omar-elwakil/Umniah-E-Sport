using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Arenas.Quereis.GetAllArenas
{
    public class GetAllArenasQuery :IRequest<List<ArenaCardVM>>
    {
    }
}
