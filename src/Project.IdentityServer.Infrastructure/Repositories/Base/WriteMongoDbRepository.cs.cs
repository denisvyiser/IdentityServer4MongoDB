using Project.identityserver.Domain.Core.Interfaces.Repositories;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Infrastructure.Contexts.MongoDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Infrastructure.Repositories.Base
{
    public abstract class WriteMongoDbRepository<TEntity> : MongoRepository<TEntity>, IWriteMongoDbRepository<TEntity> where TEntity : Entity
    {
        public WriteMongoDbRepository(IWriteMongoDbContext context) : base(context)
        {
        }
    }
}
