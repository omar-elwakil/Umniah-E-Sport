using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGames.Commands.DeleteCasualGame
{
    public class DeleteCasualGameCommand : IRequest<DeleteCasualGameResponse>
    {
        public int Id { get; set; }
    }
}
