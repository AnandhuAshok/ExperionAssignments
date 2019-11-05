using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>();

        [HttpPost("api/employees")]
        public IActionResult CreateEmployee(EmployeeCreationDto employee)
        {
            var lastEmployee = _employees.OrderByDescending(x => x.Id).LastOrDefault();

            int id = lastEmployee == null ? 1 : lastEmployee.Id + 1;

            var employeeToBeAdded = new Employee
            {
                Id = id,
                Department = employee.Department,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber
            };

            _employees.Add(employeeToBeAdded);
            return Ok(employeeToBeAdded.Id);
        }

        [HttpGet("api/employees")]
        public IActionResult GetEmployees()
        {
            return Ok(_employees);
        }

        [HttpGet("api/employees/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employees.SingleOrDefault(x => x.Id == id);

            if (employee == null)
                return NotFound();

            return Ok(new EmployeeDetailsDto
            {
                Id = employee.Id,
                Department = employee.Department,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber
            });
        }
    }
}