using EmployeeManagementZooBookData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementZooBookTests
{
    [TestClass]
    public class EmployeeServiceTests : ServiceIntegrationTest
    {
        private async Task SeedData()
        {
            var employee1 = new Employee
            {
                FirstName = "Arthur",
                MiddleName = "Conan",
                LastName = "Doyle"
            };
            _context.Employees.Add(employee1);
            await _context.SaveChangesAsync();

            var employee2 = new Employee
            {
                FirstName = "Humayun",
                MiddleName = "",
                LastName = "Ahmed"
            };
            _context.Employees.Add(employee2);
            await _context.SaveChangesAsync();

            var employee3 = new Employee
            {
                FirstName = "Eric",
                MiddleName = "Maria",
                LastName = "Remarque"
            };
            _context.Employees.Add(employee3);
            await _context.SaveChangesAsync();
        }


        [TestMethod]
        public async Task GetEmployeeById()
        {
            await SeedData();

            var result = _employeeService.GetEmployeeByIdAsync(1);

            Assert.IsNotNull(result.Result);
            Assert.AreEqual(1, 1);
            Assert.AreNotEqual(500, 1);
        }

        [TestMethod]
        public async Task GetEmployeesAsync()
        {
            await SeedData();

            var result = await _employeeService.GetEmployeesAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Humayun", result[1].FirstName);

        }

        [TestMethod]
        public async Task CreateEmployee()
        {
            var employee1 = new Employee
            {
                FirstName = "Arthur",
                MiddleName = "Conan",
                LastName = "Doyle"
            };
            _context.Employees.Add(employee1);
            await _context.SaveChangesAsync();

            var result = await _employeeService.GetEmployeeByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreNotEqual(500, 1);
        }

        [TestMethod]
        public async Task DeleteEmployee()
        {
            await SeedData();

            await _employeeService.DeleteByIdAsync(1);

            var result1 = await _employeeService.GetEmployeeByIdAsync(1);
            var result2 = await _employeeService.GetEmployeesAsync();

            Assert.IsNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreNotEqual(3, result2.Count);

        }

        [TestMethod]
        public async Task UpdateEmployee()
        {
            await SeedData();

            var emp = await _employeeService.GetEmployeeByIdAsync(2);
            emp.FirstName = "Rafat";
            emp.LastName = "Ahmad";

            await _employeeService.UpdateAsync(emp);

            var result = await _employeeService.GetEmployeeByIdAsync(2);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("Rafat", result.FirstName);

        }
    }
}
