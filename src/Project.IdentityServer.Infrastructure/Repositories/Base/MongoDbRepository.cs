using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Infrastructure.Contexts.MongoDb;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.identityserver.Infrastructure.Repositories
{
    public abstract class MongoRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity : Entity
    {
        protected readonly IMongoDbContext _context;
        protected readonly IMongoCollection<TEntity> _collection;
        //protected readonly IMongoCollection<BsonDocument> _collectionBson;

        public MongoRepository(IMongoDbContext context)
        {
            _context = context;
            _collection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
            //_collectionBson = _context.GetCollection<BsonDocument>(typeof(TEntity).Name);
        }


        public virtual async Task<PagedListMongo<TEntity>> GetAllPagedAsync(Order order, Page page, FilterDefinition<TEntity> filter = null)
        {
            SortDefinition<TEntity> sortDefinition = new BsonDocument(string.IsNullOrEmpty(order.Property) ? "Id" : order.Property, order.Crescent ? 1 : -1);

            var count = await _collection.Find(filter ?? Builders<TEntity>.Filter.Empty).CountDocumentsAsync();
            var result = await _collection.Aggregate()
                .Match(filter ?? Builders<TEntity>.Filter.Empty)
                .Sort(sortDefinition)
                .Skip((page.Index - 1) * page.Quantity)
                .Limit(page.Quantity)
                .ToListAsync();
            var pagination = new PaginationObject
            {
                Order = order,
                Page = page
            };

            return new PagedListMongo<TEntity>(result.AsQueryable(), Convert.ToInt32(count), pagination);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(
            FilterDefinition<TEntity> filter = null,
            Func<FilterDefinition<TEntity>, List<TEntity>> whenNoExists = null,
            ProjectionDefinition<TEntity, TEntity> projection = null)
        {
            var cursor = _collection.Find(filter ?? Builders<TEntity>.Filter.Empty);

            if (projection != null)
            {
                cursor = cursor.Project(projection);
            }

            var result = await cursor.ToListAsync();

            if (!result.Any() && whenNoExists != null) return whenNoExists(filter);

            return result;
        }

        public virtual async Task<List<TEntity>> GetAllByCommandAsync(string mongoDbTextCommand)
        {
            var document = new BsonDocument()
            {
                 { "eval",  mongoDbTextCommand }
            };

            var command = new BsonDocumentCommand<BsonDocument>(document);
            var response = await Task.Run(() => _context.Database.RunCommand(command));

            return response.ToList() as List<TEntity>;
        }

        public async Task<TEntity> GetOneAsync(
            FilterDefinition<TEntity> filter = null,
            Func<FilterDefinition<TEntity>, TEntity> whenNoExists = null)
        {
            var cursor = await _collection.FindAsync(filter ?? Builders<TEntity>.Filter.Empty);

            var result = await cursor.FirstOrDefaultAsync();

            if (result == null && whenNoExists != null) return whenNoExists(filter);

            return result;
        }

        public async Task<TEntity> GetLastOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<Expression<Func<TEntity, bool>>, TEntity> whenNoExists = null)
        {
            var sort = Builders<TEntity>.Sort.Descending(x => x.CreatedAt);
            var retorn = await _collection.FindAsync(filter);
            if (retorn.FirstOrDefault() != null)
            {
                var result = await _collection.Find(filter).Sort(sort).FirstAsync();
                if (result == null && whenNoExists != null) return whenNoExists(filter);

                return result;
            }
            return null;
        }

        public virtual Task AddAsync(TEntity newEntity)
        {
            return _collection.InsertOneAsync(newEntity);
        }

        public virtual Task UpdateAsync(string key, TEntity newEntity) => UpdateAsync(Guid.Parse(key), newEntity);

        public virtual Task UpdateAsync(Guid key, TEntity newEntity)
        {
            return _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Where(x => x.Id == key), newEntity);
        }

        public virtual Task UpdateManyAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition)
        {
            return _collection.UpdateManyAsync(filter, updateDefinition);
        }

        public virtual Task RemoveAsync(string key) => RemoveAsync(Guid.Parse(key));

        public virtual Task RemoveAsync(Guid key)
        {
            return _collection.DeleteOneAsync(Builders<TEntity>.Filter.Where(x => x.Id == key));
        }

        public virtual Task<TEntity> GetByIdAsync(Guid id) => GetOneAsync(Builders<TEntity>.Filter.Where(x => x.Id == id));

        public virtual async Task<bool> ExistsByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            var reg = await GetOneAsync(expression);

            return reg != null;
        }

        public virtual async Task<long> CountAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<Expression<Func<TEntity, bool>>, List<TEntity>> whenNoExists = null,
            ProjectionDefinition<TEntity, TEntity> projection = null)
        {
            var cursor = _collection.Find(filter ?? Builders<TEntity>.Filter.Empty);

            if (projection != null)
            {
                cursor = cursor.Project(projection);
            }

            return await cursor.CountDocumentsAsync();
        }

        public virtual Task<IClientSessionHandle> StartTransactionAsync()
        {
            return _context.Client.StartSessionAsync();
        }
    }
}