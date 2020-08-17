using Microsoft.AspNetCore.Mvc;
using Project.identityserver.Application.Controller;
using Project.identityserver.Application.Services;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Interfaces.Bus;

namespace Project.identityserver.Api.Controllers
{
    [ApiVersion("1.0")]

    public class WriteIdentityResourceStoreController : ApiControllerWrite<IdentityResourceViewModel>
    {
        private readonly IWriteIdentityResourceStoreAppService _appService;

        public WriteIdentityResourceStoreController(
            IWriteIdentityResourceStoreAppService appService,
            IMediatorHandler mediator) : base(mediator, appService)
        {

            _appService = appService;
                       
        }



    }
}