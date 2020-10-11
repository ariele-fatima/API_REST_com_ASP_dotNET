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

        public HttpResponseMessage Get(int? id)
        {
            if (!id.HasValue)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);
            if(aluno == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Found, aluno);
        }

    }
}
