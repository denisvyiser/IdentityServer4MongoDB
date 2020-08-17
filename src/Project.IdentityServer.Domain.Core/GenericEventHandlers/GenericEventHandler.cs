using Project.identityserver.Domain.Core.Extensions;
using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Models;
using MediatR;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Core.GenericEventHandlers
{
    public abstract class GenericEventHandler<TEvent, TEntity> : INotificationHandler<TEvent> where TEvent : GenericEvent<TEntity> where TEntity : Entity
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly ClaimsPrincipal _user;

        public GenericEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public async Task Handle(TEvent notificationEvent, CancellationToken cancellationToken)
        {
            await ApplyEvent(notificationEvent);
        }

        private async Task ApplyEvent(TEvent notificationEvent)
        {
            var eventStore = new EventStore(
                notificationEvent.GetType().Name,
                _user.GetUserIdFromToken(),
                _user.GetUserNameFromToken(),
                DateTime.Now,
                notificationEvent.entity,
                Guid.NewGuid()
            );
            await _eventStoreRepository.AddAsync(eventStore);

            PublishEvent(notificationEvent.entity);
        }

        public virtual async Task PublishEvent(TEntity message)
        {

        }
    }
}
