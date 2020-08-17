using Project.identityserver.Domain.Core.GenericEventHandlers;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.Events;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Project.identityserver.Domain.EventHandlers
{
    public class UpdatedAllDescriptionDemoEventHandler : GenericEventHandler<UpdatedAllDescriptionDemoEvent, BsonParams>
    {
        public UpdatedAllDescriptionDemoEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user) : base(eventStoreRepository, user)
        {
        }
    }
}
