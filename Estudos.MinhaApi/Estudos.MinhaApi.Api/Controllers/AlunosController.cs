using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using Estudos.Comum.Repositorios.Interfaces;
using Estudos.MinhaApi.AcessoDados.Entity.Context;
using Estudos.MinhaApi.Dominio;
using Estudos.MinhaApi.Repositorios.Entity;

namespace Estudos.MinhaApi.Api.Controllers
{
    public class AlunosController : ApiController
    {
        private IRepositorioEstudos<Aluno, int> _repositorioAlunos 
            = new RepositorioAlunos(new MinhaApiDbContext());

        public IEnumerable<Aluno> Get()
        {
            return _repositorioAlunos.Selecionar();
        }

        public Aluno Get(int? id)
        {
            return _repositorioAlunos.SelecionarPorId(id.Value);
        }

    }
}
