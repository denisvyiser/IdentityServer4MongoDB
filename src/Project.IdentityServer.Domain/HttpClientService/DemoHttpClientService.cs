using Project.identityserver.Domain.Core.HttpClientService;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces.HttpClientService;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.HttpClientService
{
    public class DemoHttpClientService : HttpClientBase<DemoModel>, IDemoHttpClientService
    {
        public DemoHttpClientService(IHttpClientFactory clientFactory, IMediatorHandler mediator) : base(clientFactory, mediator)
        {
        }
               
    }
}
