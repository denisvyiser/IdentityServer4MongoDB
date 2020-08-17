using Project.identityserver.Domain.Core.GenericQuerys;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Models;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Core.GenericQueryHandlers
{
    public abstract class QueryHandlerGetByAsync<TQuery, TResponse> : MediatorQueryHandler<TQuery, List<TResponse>>
          where TQuery : GetByGenericQuery<TResponse>
          where TResponse : Entity
    {

        IReadMongoDbRepository<TResponse> _repository;
        
        public QueryHandlerGetByAsync(IMediatorHandler mediator, IReadMongoDbRepository<TResponse> repository) : base(mediator)
        {
            _repository = repository;
        }


        public override async Task<List<TResponse>> AfterValidation(TQuery request)
        {
            var resultado = await _repository.GetAllAsync(request.Filter,request.WhenNoExists, request.Projection);

            return resultado;
        }
    }
}

    