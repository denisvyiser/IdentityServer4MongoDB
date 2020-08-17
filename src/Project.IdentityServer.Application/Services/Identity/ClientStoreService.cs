using AutoMapper;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Queries;
using System;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public class ClientStoreService : IClientStore
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
       // private readonly DomainNotificationHandler _notifications;

        public ClientStoreService(IMapper mapper, IMediatorHandler mediator/*, DomainNotificationHandler notifications*/)
        {
            _mapper = mapper;
            _mediator = mediator;
           // _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler(); ;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var builder = Builders<ClientStore>.Filter;

            FilterDefinition<ClientStore> filter = null;

            if (!string.IsNullOrEmpty(clientId))
                filter = builder.Eq(c => c.ClientId,clientId);
                //filter = builder.Where(c => c.ClientId.Contains(clientId));

                var query = new GetClientStoreQuery()
            {
                Filter = filter

            };

            var data = await _mediator.SendQuery(query);

            return _mapper.Map<Client>(data);
                        
        }
    }
}
