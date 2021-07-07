using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagementZooBookData
{
    public interface IConfiguratorDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
