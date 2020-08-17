using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedApiScopeStoreEvent : GenericEvent<ApiScopeStore>
    {
        public UpdatedApiScopeStoreEvent(ApiScopeStore _entity) : base(_entity)
        {
        }
    }
}