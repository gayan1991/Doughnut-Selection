using Doughnut.Domain.DomainModels.Referential;
using Doughnut.Domain.Util;
using Microsoft.EntityFrameworkCore;

namespace Doughnut.Infrastructure.SeedHelper
{
    public static class SeedSelectionProcess
    {
        public static void SeedDataDoughnutSelectionProcess(this ModelBuilder builder)
        {
            #region Parent

            builder.Entity<RefSelectionProcess>().HasData(new RefSelectionProcess((int)SelectionSteps.DoIWantADoughnut, "DO I WANT A DOUGHNUT?"));

            #endregion

            #region Tier2

            builder.Entity<RefSelectionProcess>().HasData(new RefSelectionProcess((int)SelectionSteps.WantADoughnut, (int)SelectionSteps.DoIWantADoughnut, "Do I deserve it?"), "Yes");
            builder.Entity<RefSelectionProcess>().HasData(new RefSelectionProcess((int)SelectionSteps.DoNotWantADoughnut, (int)SelectionSteps.DoIWantADoughnut, "Maybe you wand an apple?", "No"));

            #endregion

            #region Tier3

            builder.Entity<RefSelectionProcess>().HasData(new RefSelectionProcess((int)SelectionSteps.DeserveIt, (int)SelectionSteps.WantADoughnut, "Are you sure?", "Yes"));
            builder.Entity<RefSelectionProcess>().HasData(new RefSelectionProcess((int)SelectionSteps.DoNotDeserveIt, (int)SelectionSteps.WantADoughnut, "Is it a good doughnut?", "No"));

            #endregion

            #region Tier4

            builder.Entity<RefSelectionProcess>().HasData(new RefSelectionProcess((int)SelectionSteps.AmSure, (int)SelectionSteps.DeserveIt, "Get it.", "Yes"));
            builder.Entity<RefSelectionProcess>().HasData(new RefSelectionProcess((int)SelectionSteps.AmNotSure, (int)SelectionSteps.DeserveIt, "Do jumping jacks first.", "No"));
            builder.Entity<RefSelectionProcess>().HasData(new RefSelectionProcess((int)SelectionSteps.ItIsAGoodDoughnut, (int)SelectionSteps.DoNotDeserveIt, "What are you waiting for? Grab it now.", "Yes"));
            builder.Entity<RefSelectionProcess>().HasData(new RefSelectionProcess((int)SelectionSteps.ItIsNotAGoodDoughnut, (int)SelectionSteps.DoNotDeserveIt, "Wait 'till you find a sinful unforgettable doughnut.", "No"));

            #endregion
        }
    }
}
