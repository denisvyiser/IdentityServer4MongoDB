using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedResourcesStoreEvent : GenericEvent<ResourcesStore>
    {
        public UpdatedResourcesStoreEvent(ResourcesStore _entity) : base(_entity)
        {
        }
    }
}