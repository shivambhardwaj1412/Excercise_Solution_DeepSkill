using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice Johnson", Department = "Engineering", Salary = 75000 },
            new Employee { Id = 2, Name = "Bob Smith",    Department = "HR",          Salary = 55000 },
            new Employee { Id = 3, Name = "Carol White",  Department = "Finance",     Salary = 65000 }
        };

        // GET: api/Emp
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_employees);
        }

        // GET: api/Emp/1
        [HttpGet("{id}", Name = "GetEmployeeById")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        // POST: api/Emp
        [HttpPost(Name = "CreateEmployee")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return CreatedAtRoute("GetEmployeeById", new { id = employee.Id }, employee);
        }

        // PUT: api/Emp/1
        [HttpPut("{id}", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null) return NotFound();
            existing.Name       = employee.Name;
            existing.Department = employee.Department;
            existing.Salary     = employee.Salary;
            return NoContent();
        }

        // DELETE: api/Emp/1
        [HttpDelete("{id}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            _employees.Remove(emp);
            return NoContent();
        }
    }
}
