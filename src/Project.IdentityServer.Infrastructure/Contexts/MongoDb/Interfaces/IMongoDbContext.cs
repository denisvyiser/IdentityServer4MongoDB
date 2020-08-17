using MongoDB.Driver;
using System;

namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public interface IMongoDbContext : IDisposable
    {
        IMongoDatabase Database { get; }
        IMongoCollection<T> GetCollection<T>(string collectionName);
        IMongoClient Client { get; }
    }
}