using Estudos.MinhaApi.Api.DTOs;
using Estudos.MinhaApi.Api.HATEOAS.ResourceBuilders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace Estudos.MinhaApi.Api.HATEOAS.ResourceBuilders.Impl
{
    public class AlunoDTOResourceBuilder : IResourceBuilder
    {
        public void BuildResource(object resource, HttpRequestMessage request)
        {
            AlunoDTO dto = resource as AlunoDTO;
            if(dto == null)
            {
                throw new ArgumentException($"Era esperado um AlunoDTO, porém, foi enviado um {resource.GetType().Name}");
            }
            UrlHelper urlHelper = new UrlHelper(request);
            string alunoDTORoute = urlHelper.Link("DefaultApi", new { controller = "Alunos", id = dto.Id});
            dto.Links.Add(new RestLink 
            { 
                Rel = "self",
                Hret = alunoDTORoute
            });
            dto.Links.Add(new RestLink
            { 
                Rel = "edit",
                Hret = alunoDTORoute
            });
            dto.Links.Add(new RestLink
            {
                Rel = "delete",
                Hret = alunoDTORoute
            });

        }
    }
}