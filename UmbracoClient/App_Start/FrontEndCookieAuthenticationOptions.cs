using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

namespace UmbracoClient.App_Start
{
    /// <summary>
    /// Cookie authentication options for Umbraco front-end authentication
    /// </summary>
    public class FrontEndCookieAuthenticationOptions : CookieAuthenticationOptions
    {
        public FrontEndCookieAuthenticationOptions()
        {
            CookieManager = new FrontEndCookieManager();
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
        }
    }
}