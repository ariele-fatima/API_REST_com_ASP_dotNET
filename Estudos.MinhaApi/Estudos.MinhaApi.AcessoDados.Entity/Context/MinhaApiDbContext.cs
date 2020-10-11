using Estudos.MinhaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.MinhaApi.AcessoDados.Entity.Context
{
    public class MinhaApiDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        public MinhaApiDbContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
