using Umniah_E_Sport.Application.Responses;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetGame
{
    public class GetGameVM : BaseResponse
    {
        public GetGameVM() : base()
        {
        }

        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string ShortCode { get; set; }
        public string TermsAndConditionsContent_EN { get; set; }
        public string TermsAndConditionsContent_AR { get; set; }



        public bool IsExist { get; set; }
    }
}
