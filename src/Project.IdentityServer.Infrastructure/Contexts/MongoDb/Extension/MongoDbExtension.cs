using Project.identityserver.Domain.Core.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Net.Sockets;

namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public static class MongoDbExtension
    {
        public static IServiceCollection AddMongoDbContext<Config, Client>(this IServiceCollection services, IConfiguration configuration, string BindConfig) 
            where Config : MongoDbContextConfig, new()
            where Client : MongoClient
        {

            var config = new Config();

            configuration.Bind(BindConfig, config);

            if (string.IsNullOrEmpty(config.ConnectionString)) throw new Exception($"{BindConfig} connection is empty.");

            services.AddSingleton(config);
            services.AddSingleton(t =>
            {
                var settings = MongoClientSettings.FromConnectionString(config.ConnectionString);

                void SocketConfigurator(Socket s) => s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

                settings.SocketTimeout = TimeSpan.FromMinutes(5);
                settings.ConnectTimeout = TimeSpan.FromSeconds(60);
                settings.MaxConnectionIdleTime = TimeSpan.FromSeconds(30);
                settings.ClusterConfigurator = builder => builder
                    .ConfigureTcp(tcp => tcp.With(socketConfigurator: (Action<Socket>)SocketConfigurator));

                return (Client)(InstanceCreator.Create<MongoClientSettings,Client>(settings));
            });

            return services;
        }

              
    }
}