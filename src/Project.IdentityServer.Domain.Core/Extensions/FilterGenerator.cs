using Project.identityserver.Domain.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Core.Extensions
{
    public class FilterGenerator
    {
        public static FilterDefinition<TEntity> Generate<TEntity>(FilterDefinition<TEntity> filter, FilterDefinition<TEntity> newFilter) where TEntity : Entity
        {

            if (filter != null && newFilter != null)
            {
                filter = filter & newFilter;
            }
            else if (newFilter != null)
            {
                filter = newFilter;
            }

            return filter;
        }
    }
}
