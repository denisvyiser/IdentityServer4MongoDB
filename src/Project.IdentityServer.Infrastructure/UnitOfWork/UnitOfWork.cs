using Project.identityserver.Domain.Interfaces;
using Project.identityserver.Infrastructure.Contexts;
using System.Threading.Tasks;

namespace Project.identityserver.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostgreContext _context;

        //public UnitOfWork(PostgreContext context)
        //{
        //    _context = context;
        //}

        public async Task<bool> CommitAsync()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                bool success = (await _context.SaveChangesAsync()) > 0;

                if (success)
                    await transaction.CommitAsync();
                else
                    await transaction.RollbackAsync();

                return success;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}