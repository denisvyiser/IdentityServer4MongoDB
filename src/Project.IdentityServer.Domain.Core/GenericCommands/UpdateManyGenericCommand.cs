using Project.identityserver.Domain.Core.Commands;
using Project.identityserver.Domain.Core.Models;
using MongoDB.Driver;

namespace Project.identityserver.Domain.Core.GenericCommand
{
    public abstract class UpdateManyGenericCommand<TEntity> : Command where TEntity : Entity
    {

        public FilterDefinition<TEntity> _filter { get; set; }
        public UpdateDefinition<TEntity> _updateDefinition { get; set; }
        public UpdateManyGenericCommand(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition)
        {
            filter = _filter;
            updateDefinition = _updateDefinition;
        }
        public override bool IsValid()
        {
            return _filter != null && _updateDefinition != null;
        }

    }
}
