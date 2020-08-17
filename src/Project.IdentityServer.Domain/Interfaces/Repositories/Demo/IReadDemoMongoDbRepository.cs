using Project.identityserver.Domain.Core.Interfaces.Repositories;
using Project.identityserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Interfaces.Repositories
{
    public interface IReadDemoMongoDbRepository : IReadMongoDbRepository<DemoModel>
    {
    }
}
