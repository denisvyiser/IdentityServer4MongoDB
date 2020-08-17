using AutoMapper;
using Project.identityserver.Domain.Core.Commands;
using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.Core.Utils;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.Interfaces.Repositories;

namespace Project.identityserver.Domain.Core.GenericCommandHandlers
{
    public abstract class CommandHandlerRemove<TCommand, TEntity, Event> : MediatorCommandHandler<TCommand>
       where TCommand : Command
       where TEntity : Entity
       where Event : GenericEvent<TEntity>
    {

        protected IMapper _mapper;
        //IPostgreRepository<TEntity> _repository;

        IWriteMongoDbRepository<TEntity> _repository;

        public CommandHandlerRemove(IMediatorHandler mediator, IMapper mapper, IWriteMongoDbRepository<TEntity> repository) : base(mediator)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public override async Task AfterValidation(TCommand request)
        {
            var registered = await _repository.GetByIdAsync(request.Id);

            if (registered == null)
            {
                NotifyError($"O destino com código {request.Id} não existe");
                return;
            }

            await _repository.RemoveAsync(request.Id);

            if (!HasNotification())

                //await _mediator.RaiseEvent(Activator.CreateInstance(typeof(Event), new object[] { registered }) as Event);
                await _mediator.RaiseEvent(InstanceCreator.Create<TEntity, Event>(registered) as Event);
            else
                NotifyError("Commit", "Tivemos um problema ao tentar salvar seus dados.");
        }
    }
}
