using Project.identityserver.Domain.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Project.identityserver.Api.Security
{
    public class PermissionAttribute : ActionFilterAttribute
    {
        private string policy;

        public PermissionAttribute(string policy)
        {
            this.policy = policy;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ClaimsPrincipal claims = (ClaimsPrincipal)context.HttpContext
                .RequestServices.GetService(typeof(ClaimsPrincipal));

            var userClaims = claims.GetUserClaimsFromToken();

            if (userClaims != null)
                if (!userClaims.Contains(policy))
                    context.Result = new CustomForbidden();
        }
    }

    internal class CustomForbidden : ActionResult
    {
        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 401;
        }
    }
}