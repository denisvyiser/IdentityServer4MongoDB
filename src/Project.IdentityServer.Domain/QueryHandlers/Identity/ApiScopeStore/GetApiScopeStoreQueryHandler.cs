using Project.identityserver.Domain.Queries;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.GenericQueryHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;

namespace Project.identityserver.Domain.QueryHandlers
{
    public class GetApiScopeStoreQueryHandler : QueryHandlerGetAsync<GetApiScopeStoreQuery, ApiScopeStore>
    {
        //private readonly IReadApiScopeStoreMongoDbRepository _repository;

        public GetApiScopeStoreQueryHandler(
            IReadApiScopeStoreMongoDbRepository repository,
            IMediatorHandler mediator) : base(mediator, repository)
        {
          //  _repository = repository;
        }

        //public override async Task<ApiScopeStoreModel> AfterValidation(GetApiScopeStoreQuery request)
        //{
        //    return await _repository.GetOneAsync(x => x.Id == request.Id);
        //}
    }
}