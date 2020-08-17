using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Infrastructure.Repositories;
using Project.identityserver.Repository.Test.FakeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Repository.Test.FakeMongoContext
{
    public class DemoMongoRepositoryFake : MongoRepository<DemoModelFake>
    {
        public DemoMongoRepositoryFake(IReadMongoDbContext context)
            : base(context) { }
    }
}
    