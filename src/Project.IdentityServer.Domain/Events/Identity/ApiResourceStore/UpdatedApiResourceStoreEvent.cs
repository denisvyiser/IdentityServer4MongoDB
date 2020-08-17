using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedApiResourceStoreEvent : GenericEvent<ApiResourceStore>
    {
        public UpdatedApiResourceStoreEvent(ApiResourceStore _entity) : base(_entity)
        {
        }
    }
}