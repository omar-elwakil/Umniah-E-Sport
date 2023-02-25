using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetLeaderBoard
{
    public class GetLeaderBoardVM
    {
        public int Id { get; set; }
        public string Msisdn { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public ICollection<UserTournaments> UserTournaments { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<UserGames> UserGames { get; set; }
    }
}
