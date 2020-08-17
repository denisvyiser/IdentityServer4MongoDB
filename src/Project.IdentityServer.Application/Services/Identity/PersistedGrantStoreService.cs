using AutoMapper;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Core.Extensions;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public class PersistedGrantStoreService : IPersistedGrantStore
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public PersistedGrantStoreService(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
        }

        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            var builder = Builders<PersistedGrantStore>.Filter;

            FilterDefinition<PersistedGrantStore> _filter = null;

            if (!string.IsNullOrEmpty(filter.ClientId))
                _filter = builder.Eq(c => c.ClientId,filter.ClientId);

            if (!string.IsNullOrEmpty(filter.SessionId))
                _filter = FilterGenerator.Generate(_filter, builder.Eq(c => c.SessionId, filter.SessionId));

            if (!string.IsNullOrEmpty(filter.SubjectId))
                _filter = FilterGenerator.Generate(_filter, builder.Eq(c => c.SubjectId, filter.SubjectId));

            if (!string.IsNullOrEmpty(filter.Type))
                _filter = FilterGenerator.Generate(_filter, builder.Eq(c => c.Type, filter.Type));

            var query = new GetByPersistedGrantStoreQuery()
            {
                Filter = _filter

            };

            var data = await _mediator.SendQuery(query);

            return _mapper.Map<List<PersistedGrant>>(data);
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            var builder = Builders<PersistedGrantStore>.Filter;

            FilterDefinition<PersistedGrantStore> filter = null;

            if (!string.IsNullOrEmpty(key))
                filter = builder.Eq(c => c.Key, key);

            var query = new GetPersistedGrantStoreQuery()
            {
                Filter = filter

            };

            var data = await _mediator.SendQuery(query);

            return _mapper.Map<PersistedGrant>(data);
                        
        }

        public Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(string key)
        {

            var builder = Builders<PersistedGrantStore>.Filter;

            FilterDefinition<PersistedGrantStore> filter = null;

            if (!string.IsNullOrEmpty(key))
                filter = builder.Eq(c => c.Key, key);

            var query = new GetPersistedGrantStoreQuery()
            {
                Filter = filter

            };

            var data = await _mediator.SendQuery(query);

            var command = new RemovePersistedGrantStoreCommand(data.Id);
            //var command = Activator.CreateInstance(typeof(TRemoveCommand), new object[] { id }) as TRemoveCommand;
            await _mediator.SendCommand(command);

            if (_notifications.HasNotifications()) await _mediator.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao tentar remover seus dados."));
        }

        public async Task StoreAsync(PersistedGrant grant)
        {
            var command = _mapper.Map<PersistedGrantStoreCommand>(grant);

            await _mediator.SendCommand(command);

            if (_notifications.HasNotifications()) await _mediator.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao tentar salvar seus dados."));

        }
    }
}
