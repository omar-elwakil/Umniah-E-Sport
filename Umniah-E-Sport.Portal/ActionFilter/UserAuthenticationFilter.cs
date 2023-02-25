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
    public class UserAuthenticationFilter : Attribute, IActionFilter
    {
        private readonly ICookieManager _cookieManager;
        private readonly swaggerClient _swaggerClient;

        public UserAuthenticationFilter(ICookieManager cookieManager)
        {
            _cookieManager = cookieManager;
            _swaggerClient = new swaggerClient("http://api.sltech.org/Zain-E-Sport/", new HttpClient());
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            string MSISDN = context.HttpContext.Request.Query["MSISDN"].ToString();
            var MSISDNCookie = context.HttpContext.Request.Cookies["MSISDN"];
            var IsAble = false;
            if (!string.IsNullOrEmpty(MSISDNCookie))
                IsAble = _swaggerClient.IsUserAbleToSeeContentAsync(MSISDNCookie).Result;

            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

            // free access
            if (MSISDN == "SmartLinkTest" || MSISDNCookie == "SmartLinkTest")
            {
                context.HttpContext.Response.Cookies.Append("MSISDN", "SmartLinkTest", new CookieOptions { Expires = DateTime.Now.AddMinutes(5) });
            }
            else if (!IsAble)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                //redirectTargetDictionary.Add("action", "SubscriptionPage");
                redirectTargetDictionary.Add("action", "LandingPage");
                redirectTargetDictionary.Add("controller", "Subscription");
                context.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
        }
    }
}
