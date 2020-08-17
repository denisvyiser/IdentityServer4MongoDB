using Project.identityserver.Domain.Core.Interfaces.Repositories;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Infrastructure.Contexts.MongoDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Infrastructure.Repositories.Base
{
    public abstract class ReadMongoDbRepository<TEntity> : MongoRepository<TEntity>, IReadMongoDbRepository<TEntity> where TEntity : Entity
    {
        public ReadMongoDbRepository(IReadMongoDbContext context) : base(context)
        {
        }
    }
}
