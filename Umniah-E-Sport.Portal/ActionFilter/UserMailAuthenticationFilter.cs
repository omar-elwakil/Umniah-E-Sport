using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using UI.Helper.Managers.Portal;
using Umniah_E_Sport.Portal.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;


namespace Umniah_E_Sport.Portal.ActionFilter
{
    public class UserMailAuthenticationFilter : Attribute, IActionFilter
    {
        private readonly ICookieManager _cookieManager;
        private readonly swaggerClient _swaggerClient;

        public UserMailAuthenticationFilter(ICookieManager cookieManager)
        {
            _cookieManager = cookieManager;
            _swaggerClient = new swaggerClient("http://api.sltech.org/Umniah-E-Sport/", new HttpClient());
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string email = context.HttpContext.Request.Query["EMAIL"].ToString();
            var emailCookie = context.HttpContext.Request.Cookies["EMAIL"];

            if (email == "SmartLinkTest" || emailCookie == "SmartLinkTest")
            {
                context.HttpContext.Response.Cookies.Append("EMAIL", "SmartLinkTest", new CookieOptions { Expires = DateTime.Now.AddMinutes(5) });
            }
            else if (emailCookie == null)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                //redirectTargetDictionary.Add("action", "SubscriptionPage");
                redirectTargetDictionary.Add("action", "Landing");
                redirectTargetDictionary.Add("controller", "Subscription");
                context.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
        }
    }
}
