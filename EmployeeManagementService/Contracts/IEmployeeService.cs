using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementZooBookData;

namespace EmployeeManagementService.Contracts
{
    public interface IEmployeeService
    {
        //Fetching Data
        Task<Employee> GetEmployeeByIdAsync(long id);
        Task<IList<Employee>> GetEmployeesAsync();

        //Operations
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteByIdAsync(long id);
    }
}
