
using Project.identityserver.Domain.Core.Events;
using Project.identityserver.Domain.Core.Models;

namespace Project.identityserver.Domain.Core.GenericEvents
{
    public class GenericEvent<TEntity> : Event where TEntity : Entity
    {
        public TEntity entity { get; set; }
        public GenericEvent(TEntity _entity)
        {
            this.entity = _entity;
        }


    }
}
