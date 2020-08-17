using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class AddedIdentityResourceStoreEvent : GenericEvent<IdentityResourceStore>
    {
        public AddedIdentityResourceStoreEvent(IdentityResourceStore _entity) : base(_entity)
        {
        }
    }
}