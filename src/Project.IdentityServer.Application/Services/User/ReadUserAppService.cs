﻿using AutoMapper;
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
    public class ReadUserAppService : ReadGenericAppService<UserViewModel, User, GetUserQuery, GetPagedUserQuery>, IReadUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public ReadUserAppService(IMapper mapper, IMediatorHandler mediator) : base(mapper,mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
        }


        public async Task<PagedListMongo<UserViewModel>> GetPagedFiltered(int page, int size, string orderProperty, bool orderCrescent, string sigla, string codigo)
        {

            
            var builder = Builders<User>.Filter;

            FilterDefinition<User> filter = null;

            if (!string.IsNullOrEmpty(sigla))
                filter = builder.Where(c => c.Username.Contains(sigla));
                       
            if (!string.IsNullOrEmpty(codigo))
                filter = FilterGenerator.Generate(filter, builder.Where(c => c.Username.ToUpper().Contains(codigo.ToUpper())));
            



            var query = new GetPagedUserQuery()
            {
                Page = new Page(page, size),
                Order = new Order(orderProperty, orderCrescent),
                Restriction = new Restriction("", Condition.Default, ""),
                Filter = filter

            };

            var paged = await _mediator.SendQuery(query);

            return _mapper.Map<PagedListMongo<UserViewModel>>(paged);
        }

    }
}