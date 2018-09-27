using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace OAuthGoogle
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var cookieOpts = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/account/login"),
                CookieSecure = CookieSecureOption.SameAsRequest
            };
            app.UseCookieAuthentication(cookieOpts);

            app.SetDefaultSignInAsAuthenticationType(cookieOpts.AuthenticationType);
            var googleOpts = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = "168100992146-gf3gn7lh4i0aabpasdfasdfasdfulf921sh2i68k41cl.apps.googleusercontent.com",
                ClientSecret = "_wR1BzvtRyT3asdfasdfCHxX7y_i8ZkS",
                Provider = new GoogleOAuth2AuthenticationProvider()                
            };
            googleOpts.Scope.Add("email");
            app.UseGoogleAuthentication(googleOpts);

            var config = new HttpConfiguration();
            config.Services.Replace(typeof(IHttpControllerTypeResolver), new ControllerResolver());
            //config.Routes.MapHttpRoute(name: "signin-google", url: "signin-google", defaults: new { controller = "Account", action = "ExternalLoginCallback" });
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);
        }
    }
}
