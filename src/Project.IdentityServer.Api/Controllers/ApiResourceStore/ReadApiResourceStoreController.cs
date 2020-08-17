using Project.identityserver.Application.Controller;
using Project.identityserver.Application.Interfaces;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.identityserver.Application.Services;

namespace Project.identityserver.Api.Controllers
{
    [ApiVersion("1.0")]

    public class ReadApiResourceStoreController : ApiControllerRead<ApiResourceViewModel>
    {
        private readonly IReadApiResourceStoreAppService _appService;

        public ReadApiResourceStoreController(
            IReadApiResourceStoreAppService appService,
            IMediatorHandler mediator) : base(mediator, appService)
        {

            _appService = appService;
                       
        }

        


    }
}