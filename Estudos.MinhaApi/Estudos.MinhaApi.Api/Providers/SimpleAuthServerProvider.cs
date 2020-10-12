using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Estudos.MinhaApi.Api.Providers
{
    public class SimpleAuthServerProvider :OAuthAuthorizationServerProvider
    {
        //esse método valida se um cliente tem permissão pra fazer uma requisição para a API
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        //esse método valida se a senha e o usuário são validos
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Acess-Control-Allow-Origin", new string[] { "*" });
            if(context.UserName != "estudoapi" || context.Password != "estudoapi") //para fins didáticos será colocado um usuário e senha fixos 
            {
                context.SetError("invalid_user_or_password", "Usuário e/ou senha incorretos. ");
                return;
            }
            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identity);
        }
    }
}