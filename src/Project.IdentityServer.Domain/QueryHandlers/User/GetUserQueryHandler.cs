using Project.identityserver.Domain.Queries;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.GenericQueryHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;

namespace Project.identityserver.Domain.QueryHandlers
{
    public class GetUserQueryHandler : QueryHandlerGetAsync<GetUserQuery, User>
    {
        //private readonly IReadUserMongoDbRepository _UserRepository;

        public GetUserQueryHandler(
            IReadUserMongoDbRepository UserRepository,
            IMediatorHandler mediator) : base(mediator, UserRepository)
        {
          //  _UserRepository = UserRepository;
        }

        //public override async Task<User> AfterValidation(GetUserQuery request)
        //{
        //    return await _UserRepository.GetOneAsync(x => x.Id == request.Id);
        //}
    }
}