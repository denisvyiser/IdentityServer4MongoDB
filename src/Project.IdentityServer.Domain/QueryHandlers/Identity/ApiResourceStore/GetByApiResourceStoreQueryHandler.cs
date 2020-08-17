using Project.identityserver.Domain.Queries;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Core.GenericQueryHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;

namespace Project.identityserver.Domain.QueryHandlers
{
    public class GetByApiResourceStoreQueryHandler : QueryHandlerGetByAsync<GetByApiResourceStoreQuery, ApiResourceStore>
    {
        //private readonly IReadDemoMongoDbRepository _demoRepository;

        public GetByApiResourceStoreQueryHandler(
            IReadApiResourceStoreMongoDbRepository repository,
            IMediatorHandler mediator) : base(mediator, repository)
        {
          //  _demoRepository = demoRepository;
        }

        //public override async Task<DemoModel> AfterValidation(GetDemoQuery request)
        //{
        //    return await _demoRepository.GetOneAsync(x => x.Id == request.Id);
        //}
    }
}