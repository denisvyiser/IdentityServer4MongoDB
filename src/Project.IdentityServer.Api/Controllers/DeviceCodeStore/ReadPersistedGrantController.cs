using Microsoft.AspNetCore.Mvc;
using Project.identityserver.Application.Controller;
using Project.identityserver.Application.Services;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Interfaces.Bus;

namespace Project.identityserver.Api.Controllers
{
    [ApiVersion("1.0")]

    public class ReadDeviceCodeController : ApiControllerRead<DeviceCodeViewModel>
    {
        private readonly IReadDeviceCodeStoreAppService _appService;

        public ReadDeviceCodeController(
            IReadDeviceCodeStoreAppService appService,
            IMediatorHandler mediator) : base(mediator, appService)
        {

            _appService = appService;
                       
        }

        


    }
}