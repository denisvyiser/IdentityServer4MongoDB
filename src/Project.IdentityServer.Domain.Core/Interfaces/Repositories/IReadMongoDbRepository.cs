using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Core.Interfaces.Repositories
{
    public interface IReadMongoDbRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity : class
    {
    }
}
