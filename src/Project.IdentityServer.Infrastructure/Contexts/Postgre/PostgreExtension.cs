using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Project.identityserver.Infrastructure.Contexts.Postgre
{
    public static class PostgreExtension
    {
        public static IServiceCollection AddPostgreContext<TContext>(
            this IServiceCollection services,
            IConfiguration configuration) where TContext : DbContext
        {
            var config = new PostgreContextConfig();
            configuration.Bind("Postgre", config);

            if (string.IsNullOrEmpty(config.ConnectionString))
                throw new Exception("Postgre connection is empty.");

            services.AddSingleton(config);
            services.AddDbContext<TContext>(opt=> opt.UseNpgsql(config.ConnectionString));
            //services.AddEntityFrameworkNpgsql()
            //    .AddDbContext<TContext>(opt =>
            //    {
            //        opt.UseNpgsql(config.ConnectionString);
            //    });
            return services;
            
        }
    }
}