using MongoDB.Driver;
using Project.identityserver.Domain.Interfaces.Repositories;
using Project.identityserver.Domain.Models;
using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.identityserver.Infrastructure.Repositories
{
    public class WriteResourcesStoreMongoDbRepository : WriteMongoDbRepository<ResourcesStore>, IWriteResourcesStoreMongoDbRepository
    {
        public WriteResourcesStoreMongoDbRepository(IWriteMongoDbContext context) : base(context)
        {
        
        }



        //Identity Interface
        //public Task<IEnumerable<ApiResourceStore>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        //{
        // IMongoCollection<ApiResourceStore> _collection = _context.GetCollection<ApiResourceStore>(typeof(ApiResourceStore).Name);

        //    //var teste = Builders<ApiResourceStore>.Filter;

        //    //teste.In(c => c.Name, apiResourceNames);



        //    throw new NotImplementedException();
        //}


        //Identity Interface
        //public Task<IEnumerable<ApiResourceStore>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        //{
        //    IMongoCollection<ApiResourceStore> _collection = _context.GetCollection<ApiResourceStore>(typeof(ApiResourceStore).Name);
        //    throw new NotImplementedException();
        //}


        //Identity Interface
        //public Task<IEnumerable<ApiScopeStore>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        //{
        //    IMongoCollection<ApiScopeStore> _collection = _context.GetCollection<ApiScopeStore>(typeof(ApiScopeStore).Name);
        //    throw new NotImplementedException();
        //}

        //Identity Interface
        //public Task<IEnumerable<IdentityResourceStore>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        //{
        //    IMongoCollection<IdentityResourceStore> _collection = _context.GetCollection<IdentityResourceStore>(typeof(IdentityResourceStore).Name);
        //    throw new NotImplementedException();
        //}

        //Identity Interface
        //public Task<ResourcesStore> GetAllResourcesAsync()
        //{
        //    IMongoCollection<ResourcesStore> _collection = _context.GetCollection<ResourcesStore>(typeof(ResourcesStore).Name);
        //    throw new NotImplementedException();
        //}
    }
}
