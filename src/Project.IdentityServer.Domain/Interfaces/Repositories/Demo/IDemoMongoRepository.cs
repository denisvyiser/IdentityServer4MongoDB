using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Interfaces
{
    /// <summary>
    /// Interce do repositório herdando o uso do repositório genérico da crosscutting
    /// </summary>
    public interface IDemoMongoRepository : IMongoDbRepository<DemoModel>
    {
    }
}