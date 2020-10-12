using System;
using System.Threading.Tasks;
using System.Web.Http;
using Estudos.MinhaApi.Api.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Estudos.MinhaApi.Api.Startup))]

namespace Estudos.MinhaApi.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true, //como não temos um certificado https, vamos permitir o uso do http, mas nunca suba em produção http 
                TokenEndpointPath = new PathString("/token"), //endpoint onde pego o token de autenticação
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(2), //duração do token
                Provider = new SimpleAuthServerProvider()//onde verifica se as credencias são validas pra solicitar um token
            };
            app.UseOAuthAuthorizationServer(oAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
