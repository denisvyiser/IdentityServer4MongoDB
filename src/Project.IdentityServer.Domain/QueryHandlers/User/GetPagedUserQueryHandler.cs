using Project.identityserver.Domain.Queries;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.GenericQueryHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Interfaces.Repositories;

namespace Project.identityserver.Domain.QueryHandlers
{
    public class GetPagedUserQueryHandler : QueryHandlerGetPaged<GetPagedUserQuery, User>
    {
        public GetPagedUserQueryHandler(
            IReadUserMongoDbRepository UserRepository,
            IMediatorHandler mediator) : base(mediator, UserRepository)
        {
            
        }
             
    }
}