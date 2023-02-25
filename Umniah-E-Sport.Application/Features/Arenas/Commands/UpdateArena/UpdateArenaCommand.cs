using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Arenas.Commands.UpdateArena
{
    public class UpdateArenaCommand : IRequest<UpdateArenaCommandResponse>
    {
        public int Id { get; set; }
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string CountryName_EN { get; set; }
        public string CountryName_AR { get; set; }
        public string ImageName { get; set; }
    }
}
