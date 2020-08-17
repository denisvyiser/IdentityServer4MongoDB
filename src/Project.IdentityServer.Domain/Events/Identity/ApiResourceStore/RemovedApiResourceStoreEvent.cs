using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class RemovedApiResourceStoreEvent : GenericEvent<ApiResourceStore>
    {
        public RemovedApiResourceStoreEvent(ApiResourceStore _entity) : base(_entity)
        {
        }
    }
}