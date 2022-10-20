using Doughnut.Domain.DomainModels.DoughnutSelection;
using Doughnut.Infrastructure.SeedHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doughnut.Domain.DomainModels.Referential;
using Doughnut.Infrastructure.EntityConfiguration.DoughnutSelection;
using Doughnut.Infrastructure.EntityConfiguration.RefSelectionProcess;

namespace Doughnut.Infrastructure
{
    public class DoughnutDbContext : DbContext
    {
        #region Doughnut Selection

        public DbSet<DoughnutSelection> DoughnutSelections { get; set; }
        public DbSet<DoughnutSelectionSteps> DoubhnutSelectionSteps { get; set; }

        #endregion

        #region Referential Data

        public DbSet<RefSelectionProcess> RefSelectionProcess { get; set; }

        #endregion
        
        public DoughnutDbContext(DbContextOptions<DoughnutDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDataDoughnutSelectionProcess();

            modelBuilder.ApplyConfiguration(new DoughnutSelectionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DoughnutSelectionStepsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RefSelectionProcessEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
