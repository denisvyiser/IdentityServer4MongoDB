using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class AddedClientStoreEvent : GenericEvent<ClientStore>
    {
        public AddedClientStoreEvent(ClientStore _entity) : base(_entity)
        {
        }
    }
}