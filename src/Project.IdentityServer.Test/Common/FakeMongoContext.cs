using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Test.Repositories;
using MongoDB.Driver;
using System;

namespace Project.identityserver.Test.Common
{
    public class FakeMongoContext : IDisposable
    {
        private readonly string databaseSuffix;
        private readonly string collection;

        public MongoDbContext Context { get; }
        public IMongoDatabase Database { get; }

        public FakeMongoContext(string collectionName)
        {
            var mongoUrl = ConfigFactory.BuildConfig()["MongoDb:ConnectionString"];

            databaseSuffix = Guid.NewGuid().ToString();
            collection = $"{collectionName}{databaseSuffix}";

            Context = new ReadMongoDbContext(
                new ReadMongoDbContextConfig { ConnectionString = mongoUrl, Database = ConfigFactory.BuildConfig()["MongoDb:ApplicationConfig"] },
                new ReadMongoClient(mongoUrl));

            Database = Context.Database;
        }

        public DemoRepository BuildDemoRepository() => new DemoRepository(Context);

        public void Dispose()
        {
            Database.DropCollection(collection);
            Context.Client.DropDatabase(ConfigFactory.BuildConfig()["MongoDb:Database"]);
        }

        public void RemoveCollections()
        {
            Dispose();
        }
    }

  

}