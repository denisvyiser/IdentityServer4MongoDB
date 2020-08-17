using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedDemoEvent : GenericEvent<DemoModel>
    {
        public UpdatedDemoEvent(DemoModel _entity) : base(_entity)
        {
        }
    }
}