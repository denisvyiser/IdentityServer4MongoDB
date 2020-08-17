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
    public class ReadClientStoreMongoDbRepository : ReadMongoDbRepository<ClientStore>, IReadClientStoreMongoDbRepository
    {
        public ReadClientStoreMongoDbRepository(IReadMongoDbContext context) : base(context)
        {
        }

        //Identity Interface
        //public async Task<ClientStore> FindClientByIdAsync(FilterDefinition<ClientStore> filter = null)
        //{
        //    var cursor = await _collection.FindAsync(filter : Builders<ClientStore>.Filter.Empty);


        //    return await cursor.FirstOrDefaultAsync();
        //}

    }
}
