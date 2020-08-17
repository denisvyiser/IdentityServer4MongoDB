using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Interfaces.Repositories;
using Project.identityserver.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Interfaces.Repositories
{
    public interface IWriteResourcesStoreMongoDbRepository : IWriteMongoDbRepository<ResourcesStore>
    {

        //FilterDefinition<ApiResourceStore> filter => IEnumerable<string> apiResourceNames
        //Task<IEnumerable<ApiResourceStore>> FindApiResourcesByNameAsync();

        //FilterDefinition<ApiResourceStore> filter => IEnumerable<string> scopeNames
        //Task<IEnumerable<ApiResourceStore>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames);

        //FilterDefinition<ApiScopeStore> filter => IEnumerable<string> scopeNames
        //Task<IEnumerable<ApiScopeStore>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames);

        //FilterDefinition<IdentityResourceStore> filter => IEnumerable<string> scopeNames
        //Task<IEnumerable<IdentityResourceStore>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames);
        //Task<ResourcesStore> GetAllResourcesAsync();

    }
}
