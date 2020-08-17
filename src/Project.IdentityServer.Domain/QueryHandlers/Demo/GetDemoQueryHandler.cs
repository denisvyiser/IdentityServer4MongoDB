using Project.identityserver.Domain.Queries;
using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using System.Threading.Tasks;
using Project.identityserver.Domain.Core.GenericQueryHandlers;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Interfaces.Repositories;

namespace Project.identityserver.Domain.QueryHandlers
{
    public class GetDemoQueryHandler : QueryHandlerGetAsync<GetDemoQuery, DemoModel>
    {
        //private readonly IReadDemoMongoDbRepository _demoRepository;

        public GetDemoQueryHandler(
            IReadDemoMongoDbRepository demoRepository,
            IMediatorHandler mediator) : base(mediator, demoRepository)
        {
          //  _demoRepository = demoRepository;
        }

        //public override async Task<DemoModel> AfterValidation(GetDemoQuery request)
        //{
        //    return await _demoRepository.GetOneAsync(x => x.Id == request.Id);
        //}
    }
}