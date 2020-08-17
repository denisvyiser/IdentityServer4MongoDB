using Project.identityserver.Domain.Core.Bus;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Project.identityserver.Domain.Interfaces.Repositories;
using Project.identityserver.Infrastructure.Contexts.MongoDb;

namespace Project.identityserver.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            //services.AddScoped<IWriteDemoMongoDbRepository, WriteDemoMongoDbRepository>();
            //services.AddScoped<IReadDemoMongoDbRepository, ReadDemoMongoRepository>();
            //services.AddScoped<IDemoPostgreRepository, DemoPostgreRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IWriteMongoDbContext, WriteMongoDbContext>();
            

            services.Scan(s => s
               .FromApplicationDependencies(a =>
               a.FullName.StartsWith("Project.identityserver")
               )
               .AddClasses().AsMatchingInterface((service, filter) =>
                   filter.Where(i => i.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase))).WithScopedLifetime()
               .AddClasses(x => x.AssignableTo(typeof(IMediator))).AsImplementedInterfaces().WithScopedLifetime()
               .AddClasses(x => x.AssignableTo(typeof(IRequestHandler<,>))).AsImplementedInterfaces().WithScopedLifetime()
               .AddClasses(x => x.AssignableTo(typeof(INotificationHandler<>))).AsImplementedInterfaces().WithScopedLifetime()
            );

            services.AddTransient(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
        }
    }
}