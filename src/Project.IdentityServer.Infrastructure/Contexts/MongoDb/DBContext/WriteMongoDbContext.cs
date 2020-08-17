
namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public class WriteMongoDbContext : MongoDbContext, IWriteMongoDbContext
    {
        public WriteMongoDbContext(WriteMongoDbContextConfig config, WriteMongoClient client) : base(config, client)
        {
        }
    }
}
