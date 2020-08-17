using AutoMapper;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Core.GenericCommandHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Interfaces.Repositories;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.CommandHandlers
{
    public class UpdateDeviceCodeStoreCommandHandler : CommandHandlerUpdate<UpdateDeviceCodeStoreCommand, DeviceCodeStore, UpdatedDeviceCodeStoreEvent>
    {
        public UpdateDeviceCodeStoreCommandHandler(IMediatorHandler mediator, IMapper mapper, IWriteDeviceCodeStoreMongoDbRepository repository) : base(mediator, mapper, repository)
        {
        }
    }
}