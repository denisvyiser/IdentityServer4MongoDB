using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Infrastructure.Repositories;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Test.Repositories
{
    public class DemoRepository : MongoRepository<DemoModel>
    {
        public DemoRepository(IMongoDbContext context)
            : base(context) { }
    }
}


