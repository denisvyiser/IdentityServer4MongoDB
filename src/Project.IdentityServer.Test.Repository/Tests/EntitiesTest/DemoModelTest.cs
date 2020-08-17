using Project.identityserver.Repository.Test.FakeModels;
using Project.identityserver.Repository.Test.Fixtures;
using Xunit;

namespace Project.identityserver.Repository.Test.Tests
{
    [Trait("Categoria","Demo Test Valid")]
    public class DemoModelValidTest : GenericTest<DemoModelFake>
    {
        public DemoModelValidTest() : base(DemoModelFixture.GerarClienteValido())
        {
            setValidador(valido);
        }

        private void valido(bool result)
        {
            Assert.True(result);
        }
        
    }

    [Trait("Categoria", "Demo Test Invalid")]
    public class DemoModelInvalidTest : GenericTest<DemoModelFake>
    {
        public DemoModelInvalidTest() : base(DemoModelFixture.GerarClienteInvalido())
        {
            setValidador(invalido);
         
        }

        private void invalido(bool result)
        {
            Assert.False(result);
        }
    }


}
