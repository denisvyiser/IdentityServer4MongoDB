using AutoMapper;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Core.GenericCommandHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Interfaces.Repositories;
using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.CommandHandlers
{
    public class UpdateUserCommandHandler : CommandHandlerUpdate<UpdateUserCommand, User, UpdatedUserEvent>
    {
        public UpdateUserCommandHandler(IMediatorHandler mediator, IMapper mapper, IWriteUserMongoDbRepository repository) : base(mediator, mapper, repository)
        {
        }
    }
}