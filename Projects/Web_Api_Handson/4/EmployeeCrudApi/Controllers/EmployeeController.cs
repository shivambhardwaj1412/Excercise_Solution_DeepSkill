using EmployeeCrudApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice Johnson", Department = "Engineering", Salary = 75000 },
            new Employee { Id = 2, Name = "Bob Smith",    Department = "HR",          Salary = 60000 },
            new Employee { Id = 3, Name = "Carol White",  Department = "Engineering", Salary = 90000 }
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetAll() => Ok(_employees);

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return BadRequest("Invalid employee id");

            existing.Name       = employee.Name;
            existing.Department = employee.Department;
            existing.Salary     = employee.Salary;

            return Ok(existing);
        }
    }
}
