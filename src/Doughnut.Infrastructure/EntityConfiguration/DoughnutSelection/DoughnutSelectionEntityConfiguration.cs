using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doughnut.Infrastructure.EntityConfiguration.DoughnutSelection
{
    internal class DoughnutSelectionEntityConfiguration : BaseEntityTypeConfiguration<Domain.DomainModels.DoughnutSelection.DoughnutSelection>
    {
        public override void DomainConfiguration(EntityTypeBuilder<Domain.DomainModels.DoughnutSelection.DoughnutSelection> builder)
        {
            builder.Property(d => d.UserId).IsRequired();
            builder.HasMany(d => d.Steps).WithOne(s => s.DoughnutSelection).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
