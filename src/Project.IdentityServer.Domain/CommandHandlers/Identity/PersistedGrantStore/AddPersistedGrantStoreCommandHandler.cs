using AutoMapper;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Core.GenericCommandHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace Project.identityserver.Domain.CommandHandlers
{
    public class AddPersistedGrantStoreCommandHandler : CommandHandlerAdd<AddPersistedGrantStoreCommand, PersistedGrantStore, AddedPersistedGrantStoreEvent>
    {
        public AddPersistedGrantStoreCommandHandler(IMediatorHandler mediator, IMapper mapper, IWritePersistedGrantStoreMongoDbRepository repository) : base(mediator, mapper, repository)
        {

        }

        //public override Expression<Func<PersistedGrantStore, bool>> generateQuery(PersistedGrantStore entity) => c => c.Description == entity.Description;
        
    }
}