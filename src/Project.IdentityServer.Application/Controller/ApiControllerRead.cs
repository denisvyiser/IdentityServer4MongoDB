using IdentityModel;
using Project.identityserver.Application.Interfaces;
using Project.identityserver.Application.Interfaces.Services;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Controller
{
    [Route("v{version:apiVersion}/[Controller]")]
    [ApiController]
    public abstract class ApiControllerRead<TView> : ControllerBase where TView : class
    {
        private readonly DomainNotificationHandler _notifications;

        protected IMediatorHandler _mediator { get; }

        private readonly IReadGenericAppService<TView> _genericAppService;

        protected ApiControllerRead(IMediatorHandler mediator, IReadGenericAppService<TView> genericAppService)
        {
            _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
            _mediator = mediator;
            _genericAppService = genericAppService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get(int page = 1, int size = 20,
            string orderProperty = "Id", string orderCrescent = "true", string filterProperty = null, string filterValue = null)
        {
            var destinos = await _genericAppService.GetPaged(page, size, orderProperty,
                Convert.ToBoolean(orderCrescent), filterProperty, filterValue);

            return Response(destinos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var destino = await _genericAppService.Get(id);

            return Response(destino);
        }
      
        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
                return Ok(new SuccessResponse<object>(result));

            return BadRequest(new BadRequestResponse(
                _notifications.GetNotifications().Select(n => n.Value)
            ));
        }

        protected IActionResult ModalStateResponse()
        {
            NotifyModelStateErrors();

            return Response();
        }

        protected IActionResult ResponseWithError(string error)
        {
            NotifyError(error);

            return Response();
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                var erroMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected IEnumerable<string> GetNotificationErrors()
        {
            return _notifications.GetNotifications().Select(t => t.Value);
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected void NotifyError(string message) => NotifyError(string.Empty, message);

        protected bool IsNullRequest(object request)
        {
            if (request != null) return false;

            NotifyError("Objeto passado é inválido. Verifique os parâmetros passados e tente novamente.");

            return true;
        }

        /// <summary>
        /// Retorna o login do usuario
        /// </summary>
        /// <returns></returns>
        protected string GetLoginName()
        {
            var profile = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "name");
            return profile.Value;
        }

        /// <summary>
        /// Retorna o nome do usuario.
        /// </summary>
        /// <returns></returns>
        protected string GetUserName()
        {
            var profile = HttpContext.User.Claims.SingleOrDefault(x => x.Type == JwtClaimTypes.GivenName);
            return profile.Value;
        }

        /// <summary>
        /// Retorna o Email do Usuario
        /// </summary>
        /// <returns></returns>
        protected string GetUserEmail()
        {
            var profile = HttpContext.User.Claims.SingleOrDefault(x => x.Type == JwtClaimTypes.Email);
            return profile.Value;
        }

        /// <summary>
        /// Retorna as politicas.
        /// </summary>
        /// <returns></returns>
        protected List<string> GetUserPolicies()
        {
               var profile = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Projectclaim");

               if (profile != null)
               {
                   return profile.Value.Split(";").ToList();
               }
               else
               {
                   return new List<string>();
               }           
        }
        
        /// <summary>
        /// Retorna o UserId
        /// </summary>
        /// <returns></returns>
        protected Guid GetUserId()
        {
                var profile = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "sub");
                return new Guid(profile.Value);
        }
        
    }

}