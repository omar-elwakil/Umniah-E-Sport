using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUsersWithKeywordOrderedByScore
{
    public class GetUsersWithKeywordOrderedByScoreVm
    {
        public int Id { get; set; }
        public string Msisdn { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public DateTime? UnsubscribeTimeStamp { get; set; }
        public DateTime SubscribeTimeStamp { get; set; }
        public bool IsSubscribe { get; set; }
    }
}
