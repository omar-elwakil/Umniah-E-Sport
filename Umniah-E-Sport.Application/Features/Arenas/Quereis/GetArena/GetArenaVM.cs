using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Arenas.Quereis.GetArena
{
    public class GetArenaVM
    {
        public int Id { get; set; }
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string CountryName_EN { get; set; }
        public string CountryName_AR { get; set; }
        public string ImageName { get; set; }
        public int NumberOfTournaments { get; set; }
    }
}
