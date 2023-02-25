using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helper.Managers.Portal
{
    public interface ICookieManager
    {
        public string GetCookieByName(string cookieName);
        public void SetCookie(string cookieName, string cookieValue, int numberOfDays, CookieOptions cookieOpj);
        public void RemoveCookieByName(string cookieName);
    }
    public class CookieManager: ICookieManager  
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookieManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCookieByName(string cookieName)
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies[cookieName] != null)
            {
                return _httpContextAccessor.HttpContext.Request.Cookies[cookieName];
            }
            else
            {
                return null;
            }
        }

        public void RemoveCookieByName(string cookieName)
        {
            //Fetch the Cookie using its Key.
            var cookie = _httpContextAccessor.HttpContext.Request.Cookies[cookieName];

            if (cookie != null)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookieName);
            }
        }

        public void SetCookie(string cookieName, string cookieValue, int numberOfDays, CookieOptions cookieOpj)
        {
            cookieOpj.Expires = DateTime.Now.AddDays(numberOfDays);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, cookieValue, cookieOpj);
        }
    }
}
