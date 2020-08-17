using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedClientStoreEvent : GenericEvent<ClientStore>
    {
        public UpdatedClientStoreEvent(ClientStore _entity) : base(_entity)
        {
        }
    }
}