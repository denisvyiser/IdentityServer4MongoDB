
using MongoDB.Driver;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.Core.Queries;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Core.GenericQuerys
{
    public abstract class GetGenericQuery<TEntity> : Query<TEntity> where TEntity : Entity
    {
        public FilterDefinition<TEntity> Filter { get; set; }
        public Func<FilterDefinition<TEntity>, TEntity> WhenNoExists { get; set; }
               
        public override bool IsValid()
        {
            return Filter != null;
        }
    }
}
