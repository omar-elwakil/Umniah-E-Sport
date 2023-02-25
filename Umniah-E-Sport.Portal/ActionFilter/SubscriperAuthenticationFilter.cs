using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UI.Helper.Managers.Portal;

namespace Umniah_E_Sport.Portal.ActionFilter
{
    public class SubscriperAuthenticationFilter : Attribute, IActionFilter
    {
  
        //private readonly ISubscriptionManager _subscriptionManager;
        private readonly ICookieManager _cookieManager;

        public SubscriperAuthenticationFilter(ICookieManager cookieManager)
        {
            _cookieManager = cookieManager;
        
        }
            public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var MSISDNCookie = context.HttpContext.Request.Cookies["MSISDN"];
            bool isSub = false;
            // free access
            if (MSISDNCookie == "SmartLinkTest")
            {

            }
          /*  else if (!string.IsNullOrEmpty(MSISDNCookie))
            {
                int serviceId = _path.Value.serviceId;
                isSub = _subscriptionManager.Inquiry(MSISDNCookie, serviceId);

                if (!isSub)
                {
                    RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                    //redirectTargetDictionary.Add("action", "SubscriptionPage");
                    redirectTargetDictionary.Add("action", "Index");
                    redirectTargetDictionary.Add("controller", "Subscription");
                    context.Result = new RedirectToRouteResult(redirectTargetDictionary);

                    context.HttpContext.Session.SetString("userStatus", "loggedIn");
                }
                {
                    context.HttpContext.Session.SetString("userStatus", "subscribed");

                }
            }*/
            else
            {
                // refirect to login page 
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                //redirectTargetDictionary.Add("action", "SubscriptionPage");
                redirectTargetDictionary.Add("action", "Index");
                redirectTargetDictionary.Add("controller", "Subscription");
                context.Result = new RedirectToRouteResult(redirectTargetDictionary);
                context.HttpContext.Session.SetString("userStatus", "UnloggedIn");

            }

        }
    }
}
