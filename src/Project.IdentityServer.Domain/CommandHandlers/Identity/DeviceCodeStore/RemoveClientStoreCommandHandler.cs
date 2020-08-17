using AutoMapper;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Core.GenericCommandHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;

namespace Project.identityserver.Domain.CommandHandlers
{
    public class RemoveDeviceCodeStoreCommandHandler : CommandHandlerRemove<RemoveDeviceCodeStoreCommand, DeviceCodeStore, UpdatedDeviceCodeStoreEvent>

    {
        public RemoveDeviceCodeStoreCommandHandler(IMediatorHandler mediator, IMapper mapper, IWriteDeviceCodeStoreMongoDbRepository repository) : base(mediator, mapper, repository)
        {
        }
    }
}