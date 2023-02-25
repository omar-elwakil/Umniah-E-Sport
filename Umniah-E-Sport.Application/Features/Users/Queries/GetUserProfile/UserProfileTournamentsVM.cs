namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUserProfile
{
    public class UserProfileTournamentsVM
    {
        public int Id { get; set; }
        public string Organizer_EN { get; set; }
        public string Organizer_AR { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public long TimeStamp { get; set; }
        public string ImageName { get; set; }
    }
}