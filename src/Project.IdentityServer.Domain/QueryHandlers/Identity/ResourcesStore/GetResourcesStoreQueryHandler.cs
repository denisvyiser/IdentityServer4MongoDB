using Project.identityserver.Domain.Queries;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.GenericQueryHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;

namespace Project.identityserver.Domain.QueryHandlers
{
    public class GetResourcesStoreQueryHandler : QueryHandlerGetAsync<GetResourcesStoreQuery, ResourcesStore>
    {
        //private readonly IReadResourcesStoreMongoDbRepository _repository;

        public GetResourcesStoreQueryHandler(
            IReadResourcesStoreMongoDbRepository repository,
            IMediatorHandler mediator) : base(mediator, repository)
        {
          //  _repository = repository;
        }

        //public override async Task<ResourcesStoreModel> AfterValidation(GetResourcesStoreQuery request)
        //{
        //    return await _repository.GetOneAsync(x => x.Id == request.Id);
        //}
    }
}