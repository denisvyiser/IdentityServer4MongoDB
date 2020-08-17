using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Core.GenericQuerys;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Models;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.Interfaces.Repositories;

namespace Project.identityserver.Domain.Core.GenericQueryHandlers
{
    public abstract class QueryHandlerGetPaged<TQuery, TResponse> : MediatorQueryHandler<TQuery, PagedListMongo<TResponse>>
          where TResponse : Entity
          where TQuery : GetPagedGeneric<TResponse>

    {
        IReadMongoDbRepository<TResponse> _repository;

        public QueryHandlerGetPaged(IMediatorHandler mediator, IReadMongoDbRepository<TResponse> repository) : base(mediator)
        {
            _repository = repository;
        }

        public override async Task<PagedListMongo<TResponse>> AfterValidation(TQuery request)
        {
            var resultado = await _repository.GetAllPagedAsync(request.Order, request.Page, request.Filter);

            return resultado;
        }
    }
}
