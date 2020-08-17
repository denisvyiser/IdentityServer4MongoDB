using AutoMapper;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Core.GenericCommandHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;


namespace Project.identityserver.Domain.CommandHandlers
{
    public class AddDemoCommandHandler : CommandHandlerAdd<AddDemoCommand, DemoModel, AddedDemoEvent>
    {
        public AddDemoCommandHandler(IMediatorHandler mediator, IMapper mapper, IWriteDemoMongoDbRepository repository) : base(mediator, mapper, repository)
        {

        }

        //public override Expression<Func<DemoModel, bool>> generateQuery(DemoModel entity) => c => c.Description == entity.Description;
        
    }
}