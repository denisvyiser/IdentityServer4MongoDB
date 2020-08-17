using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class AddedUserEvent : GenericEvent<User>
    {
        public AddedUserEvent(User _entity) : base(_entity)
        {
        }
    }
}