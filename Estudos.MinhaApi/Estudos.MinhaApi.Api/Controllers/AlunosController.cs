using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
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

        public IHttpActionResult Get()
        {
            return Ok(_repositorioAlunos.Selecionar());
        }

        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);
            if(aluno == null)
            {
                return NotFound();
            }
            return Content(HttpStatusCode.Found, aluno);
        }

        public IHttpActionResult Post([FromBody]Aluno aluno)
        {
            try
            {
                _repositorioAlunos.Inserir(aluno);
                return Created($"{Request.RequestUri}/{aluno.Id}", aluno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Put(int? id, [FromBody]Aluno aluno)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                aluno.Id = id.Value;
                _repositorioAlunos.Atualizar(aluno);
                return Ok();

            } catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);
                if(aluno == null)
                {
                    return NotFound();
                }
                _repositorioAlunos.ExcluirProID(id.Value);
                return Ok();
                         }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
