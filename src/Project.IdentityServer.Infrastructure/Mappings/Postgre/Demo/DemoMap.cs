using Project.identityserver.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.identityserver.Infrastructure.Mappings.Postgre
{
    public class DemoMap : IEntityTypeConfiguration<DemoModel>
    {
        public void Configure(EntityTypeBuilder<DemoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();

            builder.ToTable("Demos");
        }
    }
}