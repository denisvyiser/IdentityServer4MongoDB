using Microsoft.AspNetCore.Mvc;
using Project.identityserver.Application.Controller;
using Project.identityserver.Application.Services;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Interfaces.Bus;

namespace Project.identityserver.Api.Controllers
{
    [ApiVersion("1.0")]

    public class WriteDeviceCodeStoreController : ApiControllerWrite<DeviceCodeViewModel>
    {
        private readonly IWriteDeviceCodeStoreAppService _appService;

        public WriteDeviceCodeStoreController(
            IWriteDeviceCodeStoreAppService appService,
            IMediatorHandler mediator) : base(mediator, appService)
        {

            _appService = appService;
                       
        }



    }
}