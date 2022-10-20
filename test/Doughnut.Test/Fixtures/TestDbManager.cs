namespace Doughnut.Test.Fixtures
{
    public class TestDbManager
    {
        private bool _disposed = false;
        private TestDoughnutDbContext TestDoughnutDbContext { get; set; }

        private static TestDbManager _testDbManager;

        private TestDbManager()
        {
            TestDoughnutDbContext = TestDoughnutDbContext.GetTestDB();
        }

        public static TestDoughnutDbContext CreateInstance()
        {
            _testDbManager = new TestDbManager();
            return _testDbManager.TestDoughnutDbContext;
        }

        public static void Dispose()
        {
            _testDbManager.TestDoughnutDbContext.Dispose();
        }
    }
}
