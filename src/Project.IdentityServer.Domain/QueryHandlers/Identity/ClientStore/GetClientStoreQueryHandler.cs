using Project.identityserver.Domain.Core.GenericQueryHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces.Repositories;
using Project.identityserver.Domain.Interfaces.Repositories;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.QueryHandlers
{
    public class GetClientStoreQueryHandler : QueryHandlerGetAsync<GetClientStoreQuery, ClientStore>
    {
        public GetClientStoreQueryHandler(IMediatorHandler mediator, IReadClientStoreMongoDbRepository repository) : base(mediator, repository)
        {
        }
    }
}
