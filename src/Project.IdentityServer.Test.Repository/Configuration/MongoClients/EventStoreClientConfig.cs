using Project.identityserver.Infrastructure.Contexts.MongoDb;

namespace Project.identityserver.Repository.Test.Configuration
{
    public class EventStoreClientConfig : ClientConfig<EventStoreClient, EventStoreContextConfig>
    {
        public EventStoreClientConfig() : base("MongoDb:EventStoreConfig")
        {
        }
    }
}
