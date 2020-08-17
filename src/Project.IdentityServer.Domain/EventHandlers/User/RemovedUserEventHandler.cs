﻿
using Project.identityserver.Domain.Core.GenericEventHandlers;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using System.Security.Claims;

namespace Project.identityserver.Domain.EventHandlers
{
    public class RemovedUserEventHandler : GenericEventHandler<RemovedUserEvent, User>
    {
        public RemovedUserEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user) : base(eventStoreRepository, user)
        {
        }
    }
}
