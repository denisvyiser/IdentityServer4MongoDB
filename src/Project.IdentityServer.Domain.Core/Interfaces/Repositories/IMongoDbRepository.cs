using Project.identityserver.Domain.Core.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Core.Interfaces
{
    public interface IMongoDbRepository<TEntity> where TEntity : class
    {
        Task<PagedListMongo<TEntity>> GetAllPagedAsync(Order order, Page page, FilterDefinition<TEntity> filter = null);
                
        Task<List<TEntity>> GetAllAsync(FilterDefinition<TEntity> filter = null,
            Func<FilterDefinition<TEntity>, List<TEntity>> whenNoExists = null,
            ProjectionDefinition<TEntity, TEntity> projection = null);

        Task<List<TEntity>> GetAllByCommandAsync(string mongoDbTextCommand);

        Task<TEntity> GetOneAsync(
            FilterDefinition<TEntity> filter = null,
            Func<FilterDefinition<TEntity>, TEntity> whenNoExists = null);

        Task<TEntity> GetLastOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<Expression<Func<TEntity, bool>>, TEntity> whenNoExists = null);
        
        Task AddAsync(TEntity newEntity);

        Task UpdateAsync(string key, TEntity newEntity);

        Task UpdateAsync(Guid key, TEntity newEntity);

        Task UpdateManyAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition);

        Task RemoveAsync(string key);

        Task RemoveAsync(Guid key);

        Task<TEntity> GetByIdAsync(Guid id);

        Task<bool> ExistsByExpressionAsync(Expression<Func<TEntity, bool>> expression);

        Task<long> CountAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<Expression<Func<TEntity, bool>>, List<TEntity>> whenNoExists = null,
            ProjectionDefinition<TEntity, TEntity> projection = null);
    }
}