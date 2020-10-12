using Estudos.Comum.Repositorios.Interfaces;
using Estudos.MinhaApi.AcessoDados.Entity.Context;
using Estudos.MinhaApi.Dominio;
using Estudos.MinhaApi.Repositorios.Entity;
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

            IRepositorioEstudos<Usuario, int> repositorioUsuario
                = new RepositorioUsuarios(new MinhaApiDbContext());

            Usuario usuario = repositorioUsuario.Selecionar().Find(x => x.Login == context.UserName && x.Senha == context.Password); ;
            if(usuario == null)
            {
                    context.SetError("invalid_user_or_password", "Usuário e/ou senha incorretos. ");
                    return;
            }

            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identity);
        }
    }
}