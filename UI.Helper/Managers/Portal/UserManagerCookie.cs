using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helper.Managers.Portal
{
    public interface IUserManagerCookie
    {
        public string GetUser();
        public string GetUserEmail();
    }
    public class UserManagerCookie: IUserManagerCookie
    {

        private readonly ICookieManager _cookieManager;

        public UserManagerCookie(ICookieManager cookieManager, IHttpContextAccessor httpContextAccessor)
        {
            _cookieManager = cookieManager;
        }

        public string GetUser()
        {
            string msisdn = _cookieManager.GetCookieByName("MSISDN");
            return msisdn;
        }

        public string GetUserEmail()
        {
            return _cookieManager.GetCookieByName("EMAIL");
        }
    }
}
