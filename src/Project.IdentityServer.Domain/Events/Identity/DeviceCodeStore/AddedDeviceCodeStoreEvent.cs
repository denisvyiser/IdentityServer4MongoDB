using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class AddedDeviceCodeStoreEvent : GenericEvent<DeviceCodeStore>
    {
        public AddedDeviceCodeStoreEvent(DeviceCodeStore _entity) : base(_entity)
        {
        }
    }
}