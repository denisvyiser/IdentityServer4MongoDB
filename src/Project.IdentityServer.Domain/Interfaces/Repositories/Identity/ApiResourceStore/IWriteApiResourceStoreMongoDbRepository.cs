using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Interfaces.Repositories;
using Project.identityserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Interfaces.Repositories
{
    public interface IWriteApiResourceStoreMongoDbRepository : IWriteMongoDbRepository<ApiResourceStore>
    {
    }
}
