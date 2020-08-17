
namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public class EventStoreContext : MongoDbContext, IEventStoreContext
    {
        public EventStoreContext(EventStoreContextConfig config, EventStoreClient client) : base(config, client)
        {
        }
    }
}