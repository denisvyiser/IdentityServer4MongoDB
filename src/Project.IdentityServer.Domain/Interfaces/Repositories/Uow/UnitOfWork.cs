using System.Threading.Tasks;

namespace Project.identityserver.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
