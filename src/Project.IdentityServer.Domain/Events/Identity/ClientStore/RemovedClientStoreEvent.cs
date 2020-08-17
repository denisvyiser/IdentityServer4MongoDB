using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class RemovedClientStoreEvent : GenericEvent<ClientStore>
    {
        public RemovedClientStoreEvent(ClientStore _entity) : base(_entity)
        {
        }
    }
}