using MongoDB.Driver;
using Project.identityserver.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Core.GenericQuerys
{
    public abstract class GetByGenericQuery<TEntity> : Query<List<TEntity>>
    {
        public FilterDefinition<TEntity> Filter { get; set; }
        public Func<FilterDefinition<TEntity>, List<TEntity>> WhenNoExists { get; set; }
        public ProjectionDefinition<TEntity, TEntity> Projection { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
