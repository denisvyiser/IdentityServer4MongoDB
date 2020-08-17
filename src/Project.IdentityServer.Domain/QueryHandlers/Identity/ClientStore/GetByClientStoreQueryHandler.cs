using Project.identityserver.Domain.Queries;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Core.GenericQueryHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;
using Project.identityserver.Domain.Core.Interfaces.Repositories;

namespace Project.identityserver.Domain.QueryHandlers.Identity
{
    public class GetByClientStoreQueryHandler : QueryHandlerGetByAsync<GetByClientStoreQuery, ClientStore>
    {
        public GetByClientStoreQueryHandler(IMediatorHandler mediator, IReadClientStoreMongoDbRepository repository) : base(mediator, repository)
        {
        }
    }
}
