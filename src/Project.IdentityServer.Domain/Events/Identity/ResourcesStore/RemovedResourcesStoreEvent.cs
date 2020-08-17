using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class RemovedResourcesStoreEvent : GenericEvent<ResourcesStore>
    {
        public RemovedResourcesStoreEvent(ResourcesStore _entity) : base(_entity)
        {
        }
    }
}