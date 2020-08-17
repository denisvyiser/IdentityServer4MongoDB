using Project.identityserver.Domain.Core.HttpClientService;
using Project.identityserver.Domain.Core.Interfaces.HttpClientService;
using Project.identityserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Interfaces
{
    public interface IDemoHttpClientService : IHttpClientBase<DemoModel>
    {

    }
}
