using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Repository.Test.Configuration;
using Project.identityserver.Repository.Test.FakeModels;
using Project.identityserver.Repository.Test.FakeMongoContext;
using MongoDB.Driver;
using System;
using Xunit;

namespace Project.identityserver.Repository.Test.Tests.Repositories
{
    //[Trait("Categoria", "Demo Test Repositório")]
    //public class DemoMongoRepositoryTest : GenericMongoRepository<ReadMongoDbContextConfig, ReadMongoClient, ReadMongoDbContextConfig, DemoModelFake, ReadMongoDbContext, DemoMongoRepositoryFake>
    //{
    //    public DemoMongoRepositoryTest() : base(new ReadMongoDbContextConfig())
    //    {
    //    }

    //    public override IMongoCollection<DemoModelFake> MongoDB()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override DemoModelFake Obj()
    //    {
    //        return new DemoModelFake(Guid.NewGuid(), "Teste Descricao");
    //    }
    //}
}
