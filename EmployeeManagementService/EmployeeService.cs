using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EmployeeManagementService.Contracts;
using EmployeeManagementZooBookData;

namespace EmployeeManagementService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ConfiguratorDbContext _context;

        public EmployeeService(ConfiguratorDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeByIdAsync(long id)
        {
            return await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
        }

        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }


        public async Task CreateAsync(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(long id)
        {
            var employee = _context.Employees.FirstOrDefault(emp => emp.Id == id);

            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
