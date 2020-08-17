using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.identityserver.Api.MiddleWares
{
    public static class WhiteListMiddlewareExtensions
    {
        public static IApplicationBuilder UseWhiteListMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WhiteListMiddleWare>();
        }
    }
}
