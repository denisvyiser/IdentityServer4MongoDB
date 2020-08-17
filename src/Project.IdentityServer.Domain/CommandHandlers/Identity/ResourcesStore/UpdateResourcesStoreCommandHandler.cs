using AutoMapper;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Core.GenericCommandHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Interfaces.Repositories;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.CommandHandlers
{
    public class UpdateResourcesStoreCommandHandler : CommandHandlerUpdate<UpdateResourcesStoreCommand, ResourcesStore, UpdatedResourcesStoreEvent>
    {
        public UpdateResourcesStoreCommandHandler(IMediatorHandler mediator, IMapper mapper, IWriteResourcesStoreMongoDbRepository repository) : base(mediator, mapper, repository)
        {
        }
    }
}