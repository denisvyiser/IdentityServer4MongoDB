using MongoDB.Driver;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Interfaces.Repositories;
using Project.identityserver.Domain.Models;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Interfaces.Repositories
{
    public interface IWriteDeviceCodeStoreMongoDbRepository : IWriteMongoDbRepository<DeviceCodeStore>
    {        
    }
}
