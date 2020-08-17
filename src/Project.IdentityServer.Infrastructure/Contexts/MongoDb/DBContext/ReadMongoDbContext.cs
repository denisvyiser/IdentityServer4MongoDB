
namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public class ReadMongoDbContext : MongoDbContext, IReadMongoDbContext
    {
        public ReadMongoDbContext(ReadMongoDbContextConfig config, ReadMongoClient client) : base(config, client)
        {
        }
    }
}
