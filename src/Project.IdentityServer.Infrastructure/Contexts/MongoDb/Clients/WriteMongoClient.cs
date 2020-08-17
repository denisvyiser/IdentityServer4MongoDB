using MongoDB.Driver;

namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public class WriteMongoClient : MongoClient
    {
        public WriteMongoClient()
        {
        }

        public WriteMongoClient(MongoClientSettings settings) : base(settings)
        {
        }

        public WriteMongoClient(MongoUrl url) : base(url)
        {
        }

        public WriteMongoClient(string connectionString) : base(connectionString)
        {
        }
    }
}
