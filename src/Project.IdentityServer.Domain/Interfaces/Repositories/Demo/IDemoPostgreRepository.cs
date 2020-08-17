using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Interfaces
{
    public interface IDemoPostgreRepository : IPostgreRepository<DemoModel>
    {
    }
}