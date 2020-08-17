using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class RemovedApiScopeStoreEvent : GenericEvent<ApiScopeStore>
    {
        public RemovedApiScopeStoreEvent(ApiScopeStore _entity) : base(_entity)
        {
        }
    }
}