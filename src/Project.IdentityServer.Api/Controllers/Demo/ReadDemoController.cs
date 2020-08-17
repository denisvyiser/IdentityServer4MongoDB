using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.identityserver.Application.Interfaces;
using Project.identityserver.Application.Controller;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Data;

namespace Project.template.Api.Controllers
{
    [ApiVersion("1.0")]

    public class ReadDemoController : ApiControllerRead<DemoViewModel>
    {
        private readonly IReadDemoAppService _appService;

        public ReadDemoController(
            IReadDemoAppService appService,
            IMediatorHandler mediator) : base(mediator, appService)
        {

            _appService = appService;
                       
        }

        /// <summary>
        /// Efetua a consulta de Pacientes
        /// </summary>
        /// <param name="page">Quantidade de Páginas</param>
        /// <param name="size">Quantidade de Registros por Páginas</param>
        /// <param name="orderProperty">Propriedade pela qual será ordenado</param>
        /// <param name="orderCrescent">Ordenação Crescente ou Decrescente</param>
        /// <param name="sigla">Quantidade de Páginas</param>
        /// <param name="codigo">Quantidade de Páginas</param>
        /// <returns>Lista ou um único Registro</returns>
        /// <response code="200">Dados consultados</response>
        /// <response code="400">Nenhum registro retornado</response>

        [Produces("application/json")]
        [HttpGet("GetBy")]
        [ProducesResponseType(typeof(PagedListMongo<DemoViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBy(int page, int size, string orderProperty, bool orderCrescent, string sigla, string codigo)
        {

            var result = await _appService.GetPagedFiltered(page, size, orderProperty, orderCrescent, sigla, codigo);
            return Response(result);
        }


    }
}