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
    public class WritePersistedGrantStoreMongoDbRepository : WriteMongoDbRepository<PersistedGrantStore>, IWritePersistedGrantStoreMongoDbRepository
    {
        public WritePersistedGrantStoreMongoDbRepository(IWriteMongoDbContext context) : base(context)
        {

        }

        //Identity Interface
        //public async Task<IEnumerable<PersistedGrantStore>> GetAllAsync(FilterDefinition<PersistedGrantStore> filter)
        //{
        //    var cursor = await _collection.FindAsync(filter ?? Builders<PersistedGrantStore>.Filter.Empty);

        //    return await cursor.ToListAsync();
        //}

        //Identity Interface
        //public async Task<PersistedGrantStore> GetAsync(FilterDefinition<PersistedGrantStore> filter)
        //{
        //    var cursor = await _collection.FindAsync(filter ?? Builders<PersistedGrantStore>.Filter.Empty);

        //    return await cursor.FirstOrDefaultAsync();
        //}

        //Identity Interface
        //public async Task RemoveAllAsync(FilterDefinition<PersistedGrantStore> filter)
        //{
        //    await _collection.DeleteManyAsync(filter ?? Builders<PersistedGrantStore>.Filter.Empty);

        //}

        //Identity Interface
        //public async Task RemoveAsync(FilterDefinition<PersistedGrantStore> filter)
        //{
        //    await _collection.FindOneAndDeleteAsync(filter ?? Builders<PersistedGrantStore>.Filter.Empty);
        //}

        //Identity Interface
        //public Task StoreAsync(PersistedGrantStore grant)
        //{
        //    return _collection.InsertOneAsync(grant);
        //}
    }
}

