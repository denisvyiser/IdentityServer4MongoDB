using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Project.identityserver.Domain.Interfaces.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.identityserver.Api.MiddleWares
{
    public class WhiteListMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IDistributedCache _distributedCache;

        public WhiteListMiddleWare(RequestDelegate next, IDistributedCache distributedCache)
        {
            _next = next;
            _distributedCache = distributedCache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var principal = context.Request.HttpContext.User as ClaimsPrincipal;

            var sub = principal.Claims?.SingleOrDefault(x => x.Type == "idRedis");

            if (sub != null)
            {
                var key = $"Token/WhiteList/{sub.Value}";

                //Set();

                // Busca o Token no REDIS
                // var value = await _helper.Get(key);
                byte[] retorno = await _distributedCache.GetAsync(key: key);

                // SE O Token Não Existir no REDIS, Retornar 401
                if (retorno == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Token Expirado ou inválido!");
                }
                else
                {
                    await _next(context);
                }

            }
            else
            {
                await _next(context);
            }

            // Call the next delegate/middleware in the pipeline

        }

     
        //public async Task<bool> Set()
        //{
        //    _distributedCache.SetString("Token/WhiteList/b3a6063a-471f-44af-a352-c00e1d96c077", "Token/WhiteList/b3a6063a-471f-44af-a352-c00e1d96c077");

        //    return true;
        //}

    }
}
