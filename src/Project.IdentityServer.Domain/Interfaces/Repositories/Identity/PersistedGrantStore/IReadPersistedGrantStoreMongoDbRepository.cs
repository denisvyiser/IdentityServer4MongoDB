using MongoDB.Driver;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Interfaces.Repositories;
using Project.identityserver.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Interfaces.Repositories
{
    public interface IReadPersistedGrantStoreMongoDbRepository : IReadMongoDbRepository<PersistedGrantStore>
    {
        //PersistedGrantFilter => string SubjectId, SessionId, ClientId, Type
        //FilterDefinition<PersistedGrantStore> filter = PersistedGrantFilter;
        //Task<IEnumerable<PersistedGrantStore>> GetAllAsync(FilterDefinition<PersistedGrantStore> filter);

        //FilterDefinition<PersistedGrantStore> filter = c=> c.key
        //Task<PersistedGrantStore> GetAsync(FilterDefinition<PersistedGrantStore> filter);
        
        //PersistedGrantFilter => string SubjectId, SessionId, ClientId, Type
        //FilterDefinition<PersistedGrantStore> filter = PersistedGrantFilter;
        //Task RemoveAllAsync(FilterDefinition<PersistedGrantStore> filter);
        
        //FilterDefinition<PersistedGrantStore> filter = c=> c.key
        //Task RemoveAsync(FilterDefinition<PersistedGrantStore> filter);
        
        //Task StoreAsync(PersistedGrantStore grant);
        
    }
}
