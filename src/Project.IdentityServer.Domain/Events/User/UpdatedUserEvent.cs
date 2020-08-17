using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedUserEvent : GenericEvent<User>
    {
        public UpdatedUserEvent(User _entity) : base(_entity)
        {
        }
    }
}