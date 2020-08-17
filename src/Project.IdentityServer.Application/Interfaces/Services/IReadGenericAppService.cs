using Project.identityserver.Domain.Core.Data;
using System;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Interfaces.Services
{
    public interface IReadGenericAppService<TView> where TView : class
    {
        Task<PagedListMongo<TView>> GetPaged(int page, int size, string orderProperty,
           bool orderCrescent, string filterProperty, string filterValue);
        Task<TView> Get(Guid id);
    }
}
