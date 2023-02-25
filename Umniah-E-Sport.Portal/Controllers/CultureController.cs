using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Portal.ActionFilter;
using System;

namespace Umniah_E_Sport.Portal.Controllers
{
    //[ServiceFilter(typeof(UserAuthenticationFilter))]
    public class CultureController : Controller
    {
        [HttpPost]
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
    }
}
