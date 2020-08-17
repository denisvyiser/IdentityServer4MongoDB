using Project.identityserver.Domain.Core.GenericEventHandlers;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using System.Security.Claims;

namespace Project.identityserver.Domain.EventHandlers.Identity
{
    public class UpdatedDeviceCodeStoreEventHandler : GenericEventHandler<UpdatedDeviceCodeStoreEvent, DeviceCodeStore>
    {
        public UpdatedDeviceCodeStoreEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user) : base(eventStoreRepository, user)
        {
        }
    }
}
