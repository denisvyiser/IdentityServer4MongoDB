using AutoMapper;
using Project.identityserver.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Project.identityserver.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();
            MappingsConfig.RegisterMappings();
        }
    }
}