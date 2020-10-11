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
using Estudos.MinhaApi.Api.AutoMapper;
using Estudos.MinhaApi.Api.DTOs;
using Estudos.MinhaApi.Api.Filters;
using Estudos.MinhaApi.Dominio;
using Estudos.MinhaApi.Repositorios.Entity;
using Microsoft.Ajax.Utilities;

namespace Estudos.MinhaApi.Api.Controllers
{
    public class AlunosController : ApiController
    {
        private IRepositorioEstudos<Aluno, int> _repositorioAlunos 
            = new RepositorioAlunos(new MinhaApiDbContext());

        public IHttpActionResult Get()
        {
            List<Aluno> alunos = _repositorioAlunos.Selecionar();
            List<AlunoDTO> dtos = AutoMapperManager.Instance.Mapper.Map<List<Aluno>, List<AlunoDTO>>(alunos);
            return Ok(dtos);
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
            AlunoDTO dto = AutoMapperManager.Instance.Mapper.Map<Aluno, AlunoDTO>(aluno);
            return Content(HttpStatusCode.Found, dto);
        }

        [ApplyModelValidation]
        public IHttpActionResult Post([FromBody]AlunoDTO dto)
        {
            try
            {
                Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(dto);
                _repositorioAlunos.Inserir(aluno);
                return Created($"{Request.RequestUri}/{aluno.Id}", aluno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ApplyModelValidation]
        public IHttpActionResult Put(int? id, [FromBody]AlunoDTO dto)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(dto);
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
