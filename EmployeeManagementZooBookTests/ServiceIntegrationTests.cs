using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EmployeeManagementService;
using EmployeeManagementService.Contracts;
using EmployeeManagementZooBookData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagementZooBookTests
{
    [TestClass]
    public abstract class ServiceIntegrationTest
    {
        protected IEmployeeService _employeeService;
        protected IConfiguration _configuration;
        protected ConfiguratorDbContext _context;

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Database.CloseConnection();
            _context.Dispose();
        }

        [TestInitialize]
        public virtual void MyTestInitialize()
        {
            var option = new DbContextOptionsBuilder<ConfiguratorDbContext>().UseSqlite("DataSource=:memory:").Options;
            _context = new ConfiguratorDbContext(option);
            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();

            _employeeService = new EmployeeService(_context);
        }
    }
}
