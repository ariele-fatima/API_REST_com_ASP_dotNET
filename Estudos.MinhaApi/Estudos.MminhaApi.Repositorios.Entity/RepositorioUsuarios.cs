using Estudos.Comum.Repositorios.Entity;
using Estudos.MinhaApi.AcessoDados.Entity.Context;
using Estudos.MinhaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.MinhaApi.Repositorios.Entity
{
    public class RepositorioUsuarios : RepositorioEstudos<Usuario, int>
    {
        public RepositorioUsuarios(MinhaApiDbContext context)
            :base(context)
        {
        }

    }
}
