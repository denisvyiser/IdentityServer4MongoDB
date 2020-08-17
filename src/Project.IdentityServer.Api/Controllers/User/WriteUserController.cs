using Project.identityserver.Application.Controller;
using Project.identityserver.Application.Interfaces;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Project.identityserver.Api.Controllers
{
    [ApiVersion("1.0")]

    public class WriteUserController : ApiControllerWrite<UserViewModel>
    {
        private readonly IWriteUserAppService _appService;

        public WriteUserController(
            IWriteUserAppService appService,
            IMediatorHandler mediator) : base(mediator, appService)
        {

            _appService = appService;
                       
        }



    }
}