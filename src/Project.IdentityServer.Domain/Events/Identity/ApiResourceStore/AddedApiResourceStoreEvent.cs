using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class AddedApiResourceStoreEvent : GenericEvent<ApiResourceStore>
    {
        public AddedApiResourceStoreEvent(ApiResourceStore _entity) : base(_entity)
        {
        }
    }
}