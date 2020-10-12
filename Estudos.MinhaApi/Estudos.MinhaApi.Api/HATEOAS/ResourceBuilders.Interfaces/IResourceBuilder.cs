using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.MinhaApi.Api.HATEOAS.ResourceBuilders.Interfaces
{
    interface IResourceBuilder
    {
        void BuildResource(object resource, HttpRequestMessage request);
    }
}
