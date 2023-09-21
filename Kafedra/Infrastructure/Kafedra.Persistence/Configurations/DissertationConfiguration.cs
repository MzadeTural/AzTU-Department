using Kafedra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kafedra.Persistence.Configurations
{
    public class DissertationConfiguration : IEntityTypeConfiguration<Dissertation>
    {
        public void Configure(EntityTypeBuilder<Dissertation> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
