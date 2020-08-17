using Project.identityserver.Domain.Core.GenericQuerys;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Models;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.Interfaces.Repositories;

namespace Project.identityserver.Domain.Core.GenericQueryHandlers
{
    public abstract class QueryHandlerGetAsync<TQuery, TResponse> : MediatorQueryHandler<TQuery, TResponse>
          where TQuery : GetGenericQuery<TResponse>
          where TResponse : Entity
    {

        IReadMongoDbRepository<TResponse> _repository;
        
        public QueryHandlerGetAsync(IMediatorHandler mediator, IReadMongoDbRepository<TResponse> repository) : base(mediator)
        {
            _repository = repository;
        }


        public override async Task<TResponse> AfterValidation(TQuery request)
        {
            var resultado = await _repository.GetOneAsync(request.Filter,request.WhenNoExists);

            return resultado;
        }
    }
}

    