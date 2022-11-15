using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNetCore.Cors;

[assembly: OwinStartup(typeof(BuddyGuard.API.Security.AuthenticationStartup))]
namespace BuddyGuard.API.Security
{
    public class AuthenticationStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors()
            var myProvider = new AuthorizationProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = myProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
