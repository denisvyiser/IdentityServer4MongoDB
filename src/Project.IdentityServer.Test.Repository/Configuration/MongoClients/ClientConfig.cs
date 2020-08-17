using Project.identityserver.Domain.Core.Utils;
using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Net.Sockets;

namespace Project.identityserver.Repository.Test.Configuration
{
    public class ClientConfig<Client, Config>
        where Client : MongoClient
        where Config : MongoDbContextConfig, new()
    {
        public Client mongoClient;
        public Config contextConfig;
        public ClientConfig(string connection)
        {
            var config = ConfigFactory.BuildConfig();

            contextConfig = new Config();

            config.Bind(connection, contextConfig);

            var settings = MongoClientSettings.FromConnectionString(contextConfig.ConnectionString);

            void SocketConfigurator(Socket s) => s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

            settings.SocketTimeout = TimeSpan.FromMinutes(5);
            settings.ConnectTimeout = TimeSpan.FromSeconds(60);
            settings.MaxConnectionIdleTime = TimeSpan.FromSeconds(30);
            settings.ClusterConfigurator = builder => builder
                .ConfigureTcp(tcp => tcp.With(socketConfigurator: (Action<Socket>)SocketConfigurator));

            mongoClient = InstanceCreator.Create<MongoClientSettings, Client>(settings) as Client;
            
        }

    }
}
