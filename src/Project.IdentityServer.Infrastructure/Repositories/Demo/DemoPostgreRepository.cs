using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Domain.Models;
using Project.identityserver.Infrastructure.Contexts;

namespace Project.identityserver.Infrastructure.Repositories
{
    public class DemoPostgreRepository : PostgreRepository<DemoModel>, IDemoPostgreRepository
    {
        //public DemoPostgreRepository(PostgreContext context)
        //    : base(context) { }
    }
}