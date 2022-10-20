using Doughnut.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Doughnut.Test.Fixtures
{
    public class TestDoughnutDbContext : DoughnutDbContext
    {
        public TestDoughnutDbContext(DbContextOptions<DoughnutDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static TestDoughnutDbContext GetTestDB()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            var options = new DbContextOptionsBuilder<DoughnutDbContext>().UseInMemoryDatabase("UserDb").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).UseInternalServiceProvider(serviceProvider).Options;

            var dbContext = new TestDoughnutDbContext(options);

            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
