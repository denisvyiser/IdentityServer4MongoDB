using AutoMapper;
using Project.identityserver.Domain.Core.Commands;
using Project.identityserver.Domain.Core.GenericCommand;
using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.Core.Utils;
using MongoDB.Bson.Serialization;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.Interfaces.Repositories;

namespace Project.identityserver.Domain.Core.GenericCommandHandlers
{
    public abstract class CommandHandlerUpdateMany<TCommand, TEntity, Event> : MediatorCommandHandler<TCommand>
          where TCommand : UpdateManyGenericCommand<TEntity>
         where TEntity : Entity
         where Event : GenericEvent<BsonParams>
    {

        protected IMapper _mapper;
        IWriteMongoDbRepository<TEntity> _repository;
        public CommandHandlerUpdateMany(IMediatorHandler mediator, IMapper mapper, IWriteMongoDbRepository<TEntity> repository) : base(mediator)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public override async Task AfterValidation(TCommand request)
        {

            await _repository.UpdateManyAsync(request._filter, request._updateDefinition);

            if (!HasNotification())
            {
                var filter = request._filter.Render(BsonSerializer.SerializerRegistry.GetSerializer<TEntity>(), BsonSerializer.SerializerRegistry);

                var definition = request._updateDefinition.Render(BsonSerializer.SerializerRegistry.GetSerializer<TEntity>(), BsonSerializer.SerializerRegistry);


                //TODO: EVENTOS PARA CACHE OU FILA
                
                //await _mediator.RaiseEvent(Activator.CreateInstance(typeof(Event), new object[] { new BsonParams(filter.ToString(), definition.ToString()) }) as Event);
                await _mediator.RaiseEvent(InstanceCreator.Create<BsonParams, Event>(new BsonParams(filter.ToString(), definition.ToString())) as Event);
            }
            else
            {
                NotifyError("Commit", "Tivemos um problema ao tentar salvar seus dados.");
            }
        }

    }
}
