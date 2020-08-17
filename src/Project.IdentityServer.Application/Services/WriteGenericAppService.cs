using AutoMapper;
using Project.identityserver.Application.Interfaces.Services;
using Project.identityserver.Domain.Core.Commands;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Domain.Core.Utils;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Services
{
    public abstract class WriteGenericAppService<TView, TEntity, TAddCommand, TUpdateCommand, TRemoveCommand> : IWriteGenericAppService<TView>
        where TView : class
         where TEntity : Entity
        where TAddCommand : Command, IAddCommand
        where TUpdateCommand : Command, IUpdateCommand
        where TRemoveCommand : Command, IRemoveCommand
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        //private readonly IUnitOfWork _uoW;
        private readonly DomainNotificationHandler _notifications;

        //public WriteGenericAppService(IMapper mapper, IMediatorHandler mediator, IUnitOfWork uoW)
        public WriteGenericAppService(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
           // _uoW = uoW;
            _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
        }

        public async Task Salvar(TView model)
        {
            var command = _mapper.Map<TAddCommand>(model);
            await _mediator.SendCommand(command);

            if (_notifications.HasNotifications()) await _mediator.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao tentar salvar seus dados."));

        }

        public async Task Atualizar(TView model)
        {
            var command = _mapper.Map<TUpdateCommand>(model);
            await _mediator.SendCommand(command);

            if (_notifications.HasNotifications()) await _mediator.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao tentar atualizar seus dados."));
        }

        public async Task Remover(Guid id)
        {
            var command = InstanceCreator.Create<Guid, TRemoveCommand>(id) as TRemoveCommand;
            //var command = Activator.CreateInstance(typeof(TRemoveCommand), new object[] { id }) as TRemoveCommand;
            await _mediator.SendCommand(command);

            if (_notifications.HasNotifications()) await _mediator.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao tentar remover seus dados."));
        }
    }
}
