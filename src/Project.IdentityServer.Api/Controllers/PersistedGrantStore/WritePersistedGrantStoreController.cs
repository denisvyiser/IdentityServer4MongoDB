using Microsoft.AspNetCore.Mvc;
using Project.identityserver.Application.Controller;
using Project.identityserver.Application.Services;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Interfaces.Bus;

namespace Project.identityserver.Api.Controllers
{
    [ApiVersion("1.0")]

    public class WritePersistedGrantStoreController : ApiControllerWrite<PersistedGrantViewModel>
    {
        private readonly IWritePersistedGrantStoreAppService _appService;

        public WritePersistedGrantStoreController(
            IWritePersistedGrantStoreAppService appService,
            IMediatorHandler mediator) : base(mediator, appService)
        {

            _appService = appService;
                       
        }



    }
}