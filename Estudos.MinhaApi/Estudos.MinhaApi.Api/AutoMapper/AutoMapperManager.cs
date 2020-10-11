using AutoMapper;
using Estudos.MinhaApi.Api.DTOs;
using Estudos.MinhaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estudos.MinhaApi.Api.AutoMapper
{
    public class AutoMapperManager
    {
        private static readonly Lazy<AutoMapperManager> _instance
            = new Lazy<AutoMapperManager>(() =>
            {
                return new AutoMapperManager();
            });
         
        public static AutoMapperManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private MapperConfiguration _config;

        public IMapper Mapper {
            get
            {
                return _config.CreateMapper();
            }
        }

        public AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Aluno, AlunoDTO>();
                cfg.CreateMap<AlunoDTO, Aluno>();
            });
        }
    }
}