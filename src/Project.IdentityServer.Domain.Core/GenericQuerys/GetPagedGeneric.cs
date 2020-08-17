
using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Core.Models;
using MongoDB.Driver;
using Project.identityserver.Domain.Core.Queries;
using System;

namespace Project.identityserver.Domain.Core.GenericQuerys
{
    public abstract class GetPagedGeneric<TEntity> : Query<PagedListMongo<TEntity>> where TEntity : Entity
    {
        public FilterDefinition<TEntity> Filter;
        public Page Page { get; set; }
        public Order Order { get; set; }
        public Restriction Restriction { get; set; }
        public override bool IsValid()
        {
            return true;
        }
    }
}
