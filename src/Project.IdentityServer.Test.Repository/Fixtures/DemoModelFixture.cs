using Project.identityserver.Repository.Test.FakeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Repository.Test.Fixtures
{
    public class DemoModelFixture
    {
        public static DemoModelFake GerarClienteValido()
        {
           return new DemoModelFake(Guid.NewGuid(), "Teste Descricao");
        }

        public static DemoModelFake GerarClienteInvalido()
        {
            return new DemoModelFake(Guid.NewGuid(), "");
        }
    }
}
