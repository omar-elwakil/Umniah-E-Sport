using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Achievements.Queries.GetUserAchievementsByUserId
{
    public class GetUserAchievementsByUserIdVm
    {
        public int Id { get; set; }
        public string UserMsisdn { get; set; }
        public string UserName { get; set; }
        public int UserScore { get; set; }
        public DateTime UserCreationTimeStamp { get; set; }
        public DateTime? UserUnsubscribeTimeStamp { get; set; }
        public DateTime UserSubscribeTimeStamp { get; set; }
        public bool UserIsSubscribe { get; set; }
        public int UserId { get; set; }
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
