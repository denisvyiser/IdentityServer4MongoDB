using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedIdentityResourceStoreEvent : GenericEvent<IdentityResourceStore>
    {
        public UpdatedIdentityResourceStoreEvent(IdentityResourceStore _entity) : base(_entity)
        {
        }
    }
}