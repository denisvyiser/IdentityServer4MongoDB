using AutoMapper;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public class DeviceFlowCodeStoreService : IDeviceFlowStore
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public DeviceFlowCodeStoreService(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
        }
        public async Task<DeviceCode> FindByDeviceCodeAsync(string deviceCode)
        {
            var builder = Builders<DeviceCodeStore>.Filter;

            FilterDefinition<DeviceCodeStore> filter = null;

            if (!string.IsNullOrEmpty(deviceCode))
                filter = builder.Eq(c => c.DeviceCode,deviceCode);

            var query = new GetDeviceCodeStoreQuery()
            {
                Filter = filter

            };

            var data = await _mediator.SendQuery(query);

            return _mapper.Map<DeviceCode>(data);
        }

        public async Task<DeviceCode> FindByUserCodeAsync(string userCode)
        {
            var builder = Builders<DeviceCodeStore>.Filter;

            FilterDefinition<DeviceCodeStore> filter = null;

            if (!string.IsNullOrEmpty(userCode))
                filter = builder.Eq(c => c.UserCode, userCode);

            var query = new GetDeviceCodeStoreQuery()
            {
                Filter = filter

            };

            var data = await _mediator.SendQuery(query);

            return _mapper.Map<DeviceCode>(data);
        }

        public async Task RemoveByDeviceCodeAsync(string deviceCode)
        {

            var builder = Builders<DeviceCodeStore>.Filter;

            FilterDefinition<DeviceCodeStore> filter = null;

            if (!string.IsNullOrEmpty(deviceCode))
                filter = builder.Eq(c => c.DeviceCode, deviceCode);

            var query = new GetDeviceCodeStoreQuery()
            {
                Filter = filter

            };

            var data = await _mediator.SendQuery(query);

            if (data != null)
            {

                var command = new RemoveDeviceCodeStoreCommand(data.Id);
                //var command = Activator.CreateInstance(typeof(TRemoveCommand), new object[] { id }) as TRemoveCommand;
                await _mediator.SendCommand(command);

                if (_notifications.HasNotifications()) await _mediator.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao tentar remover seus dados."));
            }
            else
            {
                await _mediator.RaiseEvent(new DomainNotification("Commit", "Dados não encontrados no banco."));
            }
        }

        public async Task StoreDeviceAuthorizationAsync(string deviceCode, string userCode, DeviceCode data)
        {
            var command = new AddDeviceCodeStoreCommand(Guid.Empty,true,deviceCode,userCode,data.CreationTime,data.Lifetime, data.ClientId, data.Description, data.IsOpenId, data.IsAuthorized, data.RequestedScopes, data.AuthorizedScopes, data.SessionId);
            
            await _mediator.SendCommand(command);

            if (_notifications.HasNotifications()) await _mediator.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao tentar salvar seus dados."));
        }

        public async Task UpdateByUserCodeAsync(string userCode, DeviceCode devicedata)
        {
            var builder = Builders<DeviceCodeStore>.Filter;

            FilterDefinition<DeviceCodeStore> filter = null;

            if (!string.IsNullOrEmpty(userCode))
                filter = builder.Eq(c => c.DeviceCode, userCode);

            var query = new GetDeviceCodeStoreQuery()
            {
                Filter = filter

            };

           
            var data = await _mediator.SendQuery(query);

            if (data != null)
            {

                var command = new UpdateDeviceCodeStoreCommand(Guid.Empty, true, data.DeviceCode, userCode, devicedata.CreationTime, devicedata.Lifetime, devicedata.ClientId, devicedata.Description, devicedata.IsOpenId, devicedata.IsAuthorized, devicedata.RequestedScopes, devicedata.AuthorizedScopes, devicedata.SessionId);

                await _mediator.SendCommand(command);

                if (_notifications.HasNotifications()) await _mediator.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao tentar salvar seus dados."));
            }
            else
            {
                await _mediator.RaiseEvent(new DomainNotification("Commit", "Dados não encontrados no banco."));
            }
        }
    }
}
