using MongoDB.Driver;

namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public class ReadMongoClient : MongoClient
    {
        public ReadMongoClient()
        {
        }

        public ReadMongoClient(MongoClientSettings settings) : base(settings)
        {
        }

        public ReadMongoClient(MongoUrl url) : base(url)
        {
        }

        public ReadMongoClient(string connectionString) : base(connectionString)
        {
        }
    }
}
