using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainModel = Doughnut.Domain.DomainModels.Referential;

namespace Doughnut.Infrastructure.EntityConfiguration.RefSelectionProcess
{
    internal class RefSelectionProcessEntityConfiguration : IEntityTypeConfiguration<DomainModel.RefSelectionProcess>
    {
        public void Configure(EntityTypeBuilder<DomainModel.RefSelectionProcess> builder)
        {
            builder.ToTable(nameof(RefSelectionProcess)).HasKey(r => r.Id);

            builder.Property(r => r.Id).HasDefaultValue(Guid.NewGuid());

            builder.Property(r => r.Code).IsRequired();

            builder.Property(r => r.ParentCode);

            builder.Property(r => r.Text).IsRequired().HasMaxLength(100);

            builder.Property(r => r.Action).IsRequired().HasMaxLength(10);
        }
    }
}
