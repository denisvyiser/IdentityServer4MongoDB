using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class RemovedIdentityResourceStoreEvent : GenericEvent<IdentityResourceStore>
    {
        public RemovedIdentityResourceStoreEvent(IdentityResourceStore _entity) : base(_entity)
        {
        }
    }
}