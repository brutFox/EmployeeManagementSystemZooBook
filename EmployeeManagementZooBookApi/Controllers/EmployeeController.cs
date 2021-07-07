using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementService.Contracts;
using EmployeeManagementZooBookData;

namespace EmployeeManagementZooBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("GetEmployees", Name = "GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var result = await _employeeService.GetEmployeesAsync();

                return Ok(result);
            }
            catch (Exception exc)
            {
                return NotFound(exc.Message);
            }
        }

        [HttpGet("GetEmployeeById", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(long id)
        {
            try
            {
                var result = await _employeeService.GetEmployeeByIdAsync(id);

                return Ok(result);
            }
            catch (Exception exc)
            {
                return NotFound(exc.Message);
            }
        }

        [HttpPost("CreateEmployee", Name = "CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                await _employeeService.CreateAsync(employee);

                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost("UpdateEmployee", Name = "UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                await _employeeService.UpdateAsync(employee);

                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet("DeleteEmployee", Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            try
            {
                await _employeeService.DeleteByIdAsync(id);

                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
