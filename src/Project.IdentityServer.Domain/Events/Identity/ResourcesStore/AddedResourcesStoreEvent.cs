using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class AddedResourcesStoreEvent : GenericEvent<ResourcesStore>
    {
        public AddedResourcesStoreEvent(ResourcesStore _entity) : base(_entity)
        {
        }
    }
}