using MongoDB.Driver;

namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public class EventStoreClient : MongoClient
    {
        public EventStoreClient()
        {
        }

        public EventStoreClient(MongoClientSettings settings) : base(settings)
        {
        }

        public EventStoreClient(MongoUrl url) : base(url)
        {
        }

        public EventStoreClient(string connectionString) : base(connectionString)
        {
        }
    }
}
