using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class RemovedPersistedGrantStoreEvent : GenericEvent<PersistedGrantStore>
    {
        public RemovedPersistedGrantStoreEvent(PersistedGrantStore _entity) : base(_entity)
        {
        }
    }
}