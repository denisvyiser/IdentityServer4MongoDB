using AutoMapper;
using Project.identityserver.Domain.Core.Commands;
using Project.identityserver.Domain.Core.Extensions;
using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.Core.Utils;
using System.Linq;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.Interfaces.Repositories;
using System.Linq.Expressions;
using System;

namespace Project.identityserver.Domain.Core.GenericCommandHandlers
{
    public abstract class CommandHandlerUpdate<TCommand, TEntity, Event> : MediatorCommandHandler<TCommand>
       where TCommand : Command
       where TEntity : Entity
       where Event : GenericEvent<TEntity>

    {
        protected IMapper _mapper;
        private readonly IWriteMongoDbRepository<TEntity> _repository;
        public CommandHandlerUpdate(IMediatorHandler mediator, IMapper mapper, IWriteMongoDbRepository<TEntity> repository) : base(mediator)
        {
            _mapper = mapper;
            _repository = repository;
            
        }

        public override async Task AfterValidation(TCommand request)
        {

            var entity = _mapper.Map<TEntity>(request);

            var registeredVeiculo = await _repository.GetByIdAsync(entity.Id);

            if (registeredVeiculo == null)
            {
                NotifyError($"O objeto {entity.GetType().Name} com o código {entity.Id} não existe");
                return;
            }

            var query = RepositoryExtension.LambdaUpdateGeneration(entity);

            var registered = await _repository.GetOneAsync(query);

            if (registered != null)
            {

                var type = entity.GetType();
                var properties = type.GetProperties();

                var ListProperties = properties.Where(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(PropertyValidationAttribute))).ToList();

                string message = $"O objeto {entity.GetType().Name} com o(s) valores: ";

                for (int i = 0; i < ListProperties.Count(); i++)
                {

                    if (ListProperties[i].GetValue(entity, null).ToString() == ListProperties[i].GetValue(registered, null).ToString())
                        message += $"{ListProperties[i].Name}: {ListProperties[i].GetValue(entity, null)}; ";
                }

                NotifyError(message);
                return;
            }

            entity.SetVersion();
            entity.SetUpdatedAt();
            await _repository.UpdateAsync(entity.Id,entity);

            if (!HasNotification())
            {
                //TODO: EVENTOS PARA CACHE OU FILA
                //await _mediator.RaiseEvent(Activator.CreateInstance(typeof(Event), new object[] { entity }) as Event);
                await _mediator.RaiseEvent(InstanceCreator.Create<TEntity, Event>(entity) as Event);
            }
            else
            {
                NotifyError("Commit", "Tivemos um problema ao tentar salvar seus dados.");
            }
        }

        public virtual Expression<Func<TEntity, bool>> generateQuery(TEntity entity)
        {
            return RepositoryExtension.LambdaUpdateGeneration(entity);
        }
    }
}
