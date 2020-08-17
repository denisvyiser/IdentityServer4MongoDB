using Project.identityserver.Application.Interfaces.Services;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Data;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Interfaces
{
    public interface IReadUserAppService : IReadGenericAppService<UserViewModel>
    {
        Task<PagedListMongo<UserViewModel>> GetPagedFiltered(int page, int size, string orderProperty, bool orderCrescent, string sigla, string codigo);


    }
}