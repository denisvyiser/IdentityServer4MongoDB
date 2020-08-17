using AutoMapper;
using MongoDB.Driver;
using Project.identityserver.Application.Interfaces.Services;
using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Core.Extensions;
using Project.identityserver.Domain.Core.GenericQuerys;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public abstract class ReadGenericAppService<TView, TEntity, TGet, TGetPaged> : IReadGenericAppService<TView>
        where TView : class
         where TEntity : Entity
        where TGet : GetGenericQuery<TEntity>, new()
        where TGetPaged : GetPagedGeneric<TEntity>, new()
        
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public ReadGenericAppService(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
        }

        public async Task<TView> Get(Guid id)
        {

            var builder = Builders<TEntity>.Filter;

            FilterDefinition<TEntity> filter = null;

            if (id != Guid.Empty) 
            filter = builder.Eq(c => c.Id, id);

            var query = new TGet
            {
                Filter = filter
            };

            var result = await _mediator.SendQuery(query);

            return _mapper.Map<TView>(result);
        }

        public async Task<PagedListMongo<TView>> GetPaged(int page, int size, string orderProperty, bool orderCrescent, string filterProperty, string filterValue)
        {

            //var testeEnumExtension = Condition.Default.GetDescription();
         
            var query = new TGetPaged()
            {
                Page = new Page(page, size),
                Order = new Order(orderProperty, orderCrescent),
                Restriction = new Restriction(filterProperty, Condition.Default, filterValue)
            };

            var paged = await _mediator.SendQuery(query);

            return _mapper.Map<PagedListMongo<TView>>(paged);
        }
    }
}
