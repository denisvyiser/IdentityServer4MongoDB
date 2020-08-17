using Project.identityserver.Application.Controller;
using Project.identityserver.Application.Interfaces;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Project.identityserver.Api.Controllers
{
    [ApiVersion("1.0")]

    public class ReadUserController : ApiControllerRead<UserViewModel>
    {
        private readonly IReadUserAppService _appService;

        public ReadUserController(
            IReadUserAppService appService,
            IMediatorHandler mediator) : base(mediator, appService)
        {

            _appService = appService;

            var teste = new IdentityResources.OpenId();
            var teste1 = new IdentityResources.OpenId();
        var teste2 = new IdentityResources.Email();
        var teste3 = new IdentityResources.Profile();
        var teste4 = new IdentityResources.Phone();
        var teste5 = new IdentityResources.Address();


        }

        /// <summary>
        /// Efetua a consulta de Pacientes
        /// </summary>
        /// <param name="local">Regitro do Paciente</param>
        /// <param name="sigla">Nome do Paciente</param>
        /// <param name="codigo">Sobre Nome do Paciente</param>
        /// <param name="page">Quantidade de Páginas</param>
        /// <param name="size">Quantidade de Registros por página</param>
        /// <param name="orderProperty">Nome da propriedade pela qual será ordenado o dados</param>
        /// <param name="orderCrescent">Ordenação Crescente ou Decrescente</param>
        /// <returns>Lista ou um único Registro</returns>
        /// <response code="200">Dados consultados</response>
        /// <response code="400">Nenhum registro retornado</response>

        [Produces("application/json")]
        [HttpGet("GetBy")]
        [ProducesResponseType(typeof(PagedListMongo<UserViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBy(int page, int size, string orderProperty, bool orderCrescent, string local, string sigla, string codigo)
        {

            var result = await _appService.GetPagedFiltered(page, size, orderProperty, orderCrescent, sigla, codigo);
            return Response(result);
        }


    }
}