using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.identityserver.Application.Interfaces.Services
{
    public interface IWriteGenericAppService<TView> where TView : class
    {
        Task Salvar(TView model);
        Task Remover(Guid id);

        Task Atualizar(TView model);
    }
}
