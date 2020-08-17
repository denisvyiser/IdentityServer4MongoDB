using AutoMapper;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Core.GenericCommandHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;

namespace Project.identityserver.Domain.CommandHandlers
{
    public class AddUserCommandHandler : CommandHandlerAdd<AddUserCommand, User, AddedUserEvent>
    {
        public AddUserCommandHandler(IMediatorHandler mediator, IMapper mapper, IWriteUserMongoDbRepository repository) : base(mediator, mapper, repository)
        {

        }

        //public override Expression<Func<User, bool>> generateQuery(User entity) => c => c.Description == entity.Description;
        
    }
}