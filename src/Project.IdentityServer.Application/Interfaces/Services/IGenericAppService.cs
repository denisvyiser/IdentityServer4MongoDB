using Project.identityserver.Domain.Core.Data;
using System;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Interfaces
{
    public interface IGenericAppService<TView> where TView : class
    {
        Task<PagedList<TView>> GetPaged(int page, int size, string orderProperty,
            bool orderCrescent, string filterProperty, string filterValue);
        Task<TView> Get(Guid id);
        Task Salvar(TView model);
        Task Remover(Guid id);

        Task Atualizar(TView model);
    }
}
