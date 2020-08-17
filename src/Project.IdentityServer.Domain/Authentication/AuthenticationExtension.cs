using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Builder;

namespace Project.identityserver.Domain.Authentication
{
    public static class AuthenticationExtension
    {
        public static void AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var config = new AuthConfig();

            configuration.Bind("SSO", config);

            if (string.IsNullOrEmpty(config.Server)) throw new Exception("SSO connection is empty.");

            services.AddAuthentication("Bearer").AddIdentityServerAuthentication(opt => 
            {
                opt.Authority = config.Server;
                opt.RequireHttpsMetadata = false;
                opt.ApiName = config.ApiName;
                opt.SaveToken = true;
                opt.ApiSecret = config.ApiSecret;
            });
        }
    }
}