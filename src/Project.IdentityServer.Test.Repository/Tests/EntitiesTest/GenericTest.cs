using Project.identityserver.Domain.Core.Models;
using Xunit;

namespace Project.identityserver.Repository.Test.Tests
{
    public abstract class GenericTest<T> where T : Entity
    {
        T _objeto;
                
        public delegate void Validador(bool condition);
        public Validador validador;

        public GenericTest(T objeto)
        {
            _objeto = objeto;
        }


        [Fact(DisplayName ="Novo Objeto")]
        public void NovoObjeto()
        {
           //var result = _objeto.IsValid();

           // validador(result);
            
        }

        public void setValidador(Validador @delegate)
        {
            validador = new Validador(@delegate);
        }
    }
}
