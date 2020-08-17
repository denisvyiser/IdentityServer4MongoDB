using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Core.Interfaces.Repositories
{
    public interface IWriteMongoDbRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity : class
    {
    }
}
