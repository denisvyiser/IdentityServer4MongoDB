using AutoMapper;
using Project.identityserver.Application.Interfaces;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Queries;
using MongoDB.Driver;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.Extensions;

namespace Project.identityserver.Application.Services
{
    public class ReadResourcesStoreServiceApp : ReadGenericAppService<ResourcesViewModel, ResourcesStore, GetResourcesStoreQuery, GetPagedResourcesStoreQuery>, IReadResourcesStoreAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public ReadResourcesStoreServiceApp(IMapper mapper, IMediatorHandler mediator) : base(mapper,mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
        }


        public async Task<PagedListMongo<ResourcesViewModel>> GetPagedFiltered(int page, int size, string orderProperty, bool orderCrescent, bool offlineAccess)
        {

            
            var builder = Builders<ResourcesStore>.Filter;

            FilterDefinition<ResourcesStore> filter = null;
                        
                filter = builder.Where(c => c.OfflineAccess == offlineAccess);
                       
            //if (!string.IsNullOrEmpty(codigo))
            //    filter = FilterGenerator.Generate(filter, builder.Where(c => c.Description.ToUpper().Contains(codigo.ToUpper())));
            

            var query = new GetPagedResourcesStoreQuery()
            {
                Page = new Page(page, size),
                Order = new Order(orderProperty, orderCrescent),
                Restriction = new Restriction("", Condition.Default, ""),
                Filter = filter

            };

            var paged = await _mediator.SendQuery(query);

            return _mapper.Map<PagedListMongo<ResourcesViewModel>>(paged);
        }

    }
}