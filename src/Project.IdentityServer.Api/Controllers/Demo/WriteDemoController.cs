using Microsoft.AspNetCore.Mvc;
using Project.identityserver.Application.Controller;
using Project.identityserver.Application.Interfaces;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces;
using System.Collections.Generic;

namespace Project.template.Api.Controllers
{
    [ApiVersion("1.0")]

    public class WriteDemoController : ApiControllerWrite<DemoViewModel>
    {
        private readonly IWriteDemoAppService _demoServiceApp;

        public WriteDemoController(
            IWriteDemoAppService demoServiceApp,
            IMediatorHandler mediator) : base(mediator, demoServiceApp)
        {

            _demoServiceApp = demoServiceApp;
                       
        }



    }
}