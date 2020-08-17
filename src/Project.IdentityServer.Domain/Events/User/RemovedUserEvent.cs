using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class RemovedUserEvent : GenericEvent<User>
    {
        public RemovedUserEvent(User _entity) : base(_entity)
        {
        }
    }
}