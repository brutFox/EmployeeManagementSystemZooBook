using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementZooBookData
{
    public class ConfiguratorDbContext : DbContext, IConfiguratorDbContext
    {
        public ConfiguratorDbContext(DbContextOptions<ConfiguratorDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
