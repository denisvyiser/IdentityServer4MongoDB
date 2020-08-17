using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class RemovedDeviceCodeStoreEvent : GenericEvent<DeviceCodeStore>
    {
        public RemovedDeviceCodeStoreEvent(DeviceCodeStore _entity) : base(_entity)
        {
        }
    }
}