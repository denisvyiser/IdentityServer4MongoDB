using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class RemovedDemoEvent : GenericEvent<DemoModel>
    {
        public RemovedDemoEvent(DemoModel _entity) : base(_entity)
        {
        }
    }
}