﻿using AutoMapper;
using MongoDB.Driver;
using Project.identityserver.Application.Interfaces;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public class WriteDemoAppService : WriteGenericAppService<DemoViewModel, DemoModel, AddDemoCommand, UpdateDemoCommand, RemoveDemoCommand>, IWriteDemoAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;
        //private readonly IUnitOfWork _uoW;

        public WriteDemoAppService(IMapper mapper, IMediatorHandler mediator) : base(mapper, mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
          //  _uoW = uoW;
            _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
        }

        public async Task UpdateEstatisticasUsuarioAcessos(DemoViewModel model)
        {

            var filter = Builders<DemoModel>.Filter.Where(x => x.IsActive == true);

            //Increment
            // var update = new UpdateDefinitionBuilder<DemoModel>().Inc(c => c.Acessos, 1).Set(c => c.AcessadoEm, DateTime.Now);

             var update = new UpdateDefinitionBuilder<DemoModel>().Set(c => c.Description, this + "-Ativo");


            UpdateAllDescriptionCommand command = new UpdateAllDescriptionCommand(filter, update);

            await _mediator.SendCommand(command);

            if (_notifications.HasNotifications()) await _mediator.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao tentar salvar seus dados."));

        }

        //public async Task UpdateInsetItemInCollection(DemoModel model)
        //{

        //    Expression<Func<DemoModel, IEnumerable<Endereco>>> field = c => c.Enderecos;

        //    var filter = Builders<DemoModel>.Filter.Eq(x => x.Id, model.Id);

        //    var lista = new List<string>() { "", "" };

        //    var listaString = new Endereco() { id = 1 };
        //    //Push<TItem>(Expression < Func < TDocument, IEnumerable < TItem >>> field, TItem value);


        //    var updatePerfil2 = new UpdateDefinitionBuilder<DemoModel>()
        //        .Push(field, listaString);

        //    UpdateAllDescriptionCommand command = new UpdateAllDescriptionCommand(filter, updatePerfil2);

        //}

        //public async Task UpdateremoveItemInCollection(DemoModel model)
        //{

        //    var filter = Builders<DemoModel>.Filter.Eq(x => x.Id, model.Id);

        //    var lista = new List<string>() { "", "" };

        //    var listaString = new Endereco() { id = 1 };

        //    Expression<Func<DemoModel, IEnumerable<Endereco>>> field = c => c.Enderecos;

        //    var updatePerfil2 = new UpdateDefinitionBuilder<DemoModel>()
        //        .Pull(field, listaString);

        //    //		.PullFilter


        //    UpdateAllDescriptionCommand command = new UpdateAllDescriptionCommand(filter, updatePerfil2);
        //}

    }
}