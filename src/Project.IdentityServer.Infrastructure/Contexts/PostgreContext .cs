using Project.identityserver.Domain.Models;
using Project.identityserver.Infrastructure.Mappings.Postgre;
using Microsoft.EntityFrameworkCore;

namespace Project.identityserver.Infrastructure.Contexts
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> opt)
            : base(opt) { }


        public DbSet<DemoModel> DemoModels { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DemoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}