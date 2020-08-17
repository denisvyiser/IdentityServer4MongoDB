using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedDeviceCodeStoreEvent : GenericEvent<DeviceCodeStore>
    {
        public UpdatedDeviceCodeStoreEvent(DeviceCodeStore _entity) : base(_entity)
        {
        }
    }
}