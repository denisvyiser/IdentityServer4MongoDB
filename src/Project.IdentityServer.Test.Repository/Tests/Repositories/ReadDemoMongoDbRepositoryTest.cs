using Project.identityserver.Repository.Test.FakeModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project.identityserver.Test.Repository.Tests.Repositories
{

    [Trait("Categoria", "Demo Test Repositório Read")]
    public class ReadDemoMongoDbRepositoryTest : ReadMongoDbRepositoryTest<DemoModelFake>
    {
       
        public override List<DemoModelFake> DBList()
        {
            return new List<DemoModelFake>() { new DemoModelFake(Guid.NewGuid(),"Description 1"), new DemoModelFake(Guid.NewGuid(), "Description 2") };
        }

        public override DemoModelFake Obj()
        {
            return new DemoModelFake(Guid.NewGuid(), "Description 3");
        }
    }
}
