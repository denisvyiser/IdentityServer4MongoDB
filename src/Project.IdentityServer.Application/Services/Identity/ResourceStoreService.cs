using AutoMapper;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public class ResourcesStoreAppService : IResourceStore
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        //private readonly DomainNotificationHandler _notifications;

        public ResourcesStoreAppService(IMapper mapper, IMediatorHandler mediator/*, DomainNotificationHandler notifications*/)
        {
            _mapper = mapper;
            _mediator = mediator;
            //_notifications = notifications;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            var builder = Builders<ApiResourceStore>.Filter;

            FilterDefinition<ApiResourceStore> _filter = null;

            if (apiResourceNames.Count() > 0)
                _filter = builder.In(c => c.Name, apiResourceNames);

           
            var query = new GetByApiResourceStoreQuery()
            {
                Filter = _filter

            };

            var data = await _mediator.SendQuery(query);

            return _mapper.Map<List<ApiResource>>(data);
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var builder = Builders<ApiResourceStore>.Filter;

            FilterDefinition<ApiResourceStore> _filter = null;

            if (scopeNames.Count() > 0) //where a single role has to match
                _filter = builder.AnyIn(c => c.Scopes, scopeNames);

            //where all roles have to match
            //_filter = builder.All(u => u.Roles, roles)

            var query = new GetByApiResourceStoreQuery()
            {
                Filter = _filter

            };

            var data = await _mediator.SendQuery(query);

            return _mapper.Map<List<ApiResource>>(data);
        }

        public async Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            var builder = Builders<ApiScopeStore>.Filter;

            FilterDefinition<ApiScopeStore> _filter = null;

            if (scopeNames.Count() > 0)
                _filter = builder.In(c => c.Name, scopeNames);


            var query = new GetByApiScopeStoreQuery()
            {
                Filter = _filter

            };

            var data = await _mediator.SendQuery(query);

            return _mapper.Map<List<ApiScope>>(data);
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var builder = Builders<IdentityResourceStore>.Filter;

            FilterDefinition<IdentityResourceStore> _filter = null;

            if (scopeNames.Count() > 0)
                _filter = builder.In(c => c.Name, scopeNames);


            var query = new GetByIdentityResourceStoreQuery()
            {
                Filter = _filter

            };

            var data = await _mediator.SendQuery(query);

            return _mapper.Map<List<IdentityResource>>(data);
        }

        public async Task<Resources> GetAllResourcesAsync()
        {

            var identityResources = await FindIdentityResourcesByScopeNameAsync(new List<string>());

            var apiResources = await FindApiResourcesByNameAsync(new List<string>());

            var apiScopes = await FindApiScopesByNameAsync(new List<string>());

            var resouces = new Resources(identityResources, apiResources, apiScopes);
            
            return resouces;
        }
    }
}
