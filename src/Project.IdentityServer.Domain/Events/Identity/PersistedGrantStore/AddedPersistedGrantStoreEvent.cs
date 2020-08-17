using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class AddedPersistedGrantStoreEvent : GenericEvent<PersistedGrantStore>
    {
        public AddedPersistedGrantStoreEvent(PersistedGrantStore _entity) : base(_entity)
        {
        }
    }
}