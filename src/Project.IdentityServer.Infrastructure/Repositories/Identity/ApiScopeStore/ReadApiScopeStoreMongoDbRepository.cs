using Project.identityserver.Domain.Interfaces.Repositories;
using Project.identityserver.Domain.Models;
using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Infrastructure.Repositories
{
    public class ReadApiScopeStoreMongoDbRepository : ReadMongoDbRepository<ApiScopeStore>, IReadApiScopeStoreMongoDbRepository
    {
        public ReadApiScopeStoreMongoDbRepository(IReadMongoDbContext context) : base(context)
        {
        }
    }
}
