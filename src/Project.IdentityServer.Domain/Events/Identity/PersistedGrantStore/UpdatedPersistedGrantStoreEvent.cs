using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedPersistedGrantStoreEvent : GenericEvent<PersistedGrantStore>
    {
        public UpdatedPersistedGrantStoreEvent(PersistedGrantStore _entity) : base(_entity)
        {
        }
    }
}