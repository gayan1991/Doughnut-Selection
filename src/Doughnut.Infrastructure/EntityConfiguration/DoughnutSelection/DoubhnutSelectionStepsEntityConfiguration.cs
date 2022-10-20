using Doughnut.Domain.DomainModels.DoughnutSelection;
using Doughnut.Domain.Util;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doughnut.Infrastructure.EntityConfiguration.DoughnutSelection
{
    internal class DoughnutSelectionStepsEntityConfiguration : BaseEntityTypeConfiguration<DoughnutSelectionSteps>
    {
        public override void DomainConfiguration(EntityTypeBuilder<DoughnutSelectionSteps> builder)
        {
            builder.Property(s => s.Step).IsRequired().HasMaxLength(100).HasConversion(to => to.ToString(),
                from => (SelectionSteps)Enum.Parse(typeof(SelectionSteps), from));
        }
    }
}
