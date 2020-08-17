using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class AddedDemoEvent : GenericEvent<DemoModel>
    {
        public AddedDemoEvent(DemoModel _entity) : base(_entity)
        {
        }
    }
}