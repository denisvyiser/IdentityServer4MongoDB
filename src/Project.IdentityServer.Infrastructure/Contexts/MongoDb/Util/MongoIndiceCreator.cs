using MongoDB.Driver;
using Project.identityserver.Domain.Core.Extensions;
using Project.identityserver.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public static class MongoIndiceCreator
    {

        public static void Create<TEntity>(IWriteMongoDbContext _context) where TEntity : Entity
        {
            var notificationLogBuilder = Builders<TEntity>.IndexKeys;

            var type = typeof(TEntity);
            var properties = type.GetProperties();


            var ListProperties = properties.Where(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(PropertyValidationAttribute))).ToList();

            List<CreateIndexModel<TEntity>> indices = new List<CreateIndexModel<TEntity>>();

            Expression<Func<TEntity, object>> func = null;

            ParameterExpression tpe = Expression.Parameter(typeof(TEntity), "e");

            for (int i = 0; i < ListProperties.Count(); i++)
            {
                Expression right = Expression.Property(tpe, ListProperties[i].Name);

                func = Expression.Lambda<Func<TEntity, object>>(right, tpe);

                indices.Add(new CreateIndexModel<TEntity>(notificationLogBuilder.Ascending(func), options: new CreateIndexOptions { Unique = true }));

            }

            _context.GetCollection<TEntity>(typeof(TEntity).Name).Indexes.CreateMany(indices);
        }

    }
}
