using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class AddedApiScopeStoreEvent : GenericEvent<ApiScopeStore>
    {
        public AddedApiScopeStoreEvent(ApiScopeStore _entity) : base(_entity)
        {
        }
    }
}