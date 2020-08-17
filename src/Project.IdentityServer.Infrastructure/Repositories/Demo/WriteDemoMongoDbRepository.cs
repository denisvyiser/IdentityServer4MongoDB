using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using Project.identityserver.Infrastructure.Repositories.Base;
using Project.identityserver.Domain.Interfaces.Repositories;

namespace Project.identityserver.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório herdando o uso do repositório genérico da crosscutting
    /// </summary>
    public class WriteDemoMongoDbRepository : WriteMongoDbRepository<DemoModel>, IWriteDemoMongoDbRepository
    {
        public WriteDemoMongoDbRepository(IWriteMongoDbContext context)
            : base(context) { }
    }
}

