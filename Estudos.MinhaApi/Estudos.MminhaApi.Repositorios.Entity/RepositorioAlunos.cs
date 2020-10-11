using Estudos.Comum.Repositorios.Entity;
using Estudos.MinhaApi.AcessoDados.Entity.Context;
using Estudos.MinhaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.MinhaApi.Repositorios.Entity
{
    public class RepositorioAlunos : RepositorioEstudos<Aluno, int>
    {
        public RepositorioAlunos(MinhaApiDbContext context)
            : base(context)
        {

        }
    }
}
