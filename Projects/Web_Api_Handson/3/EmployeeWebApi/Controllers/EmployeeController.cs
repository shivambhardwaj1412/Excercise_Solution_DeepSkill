using EmployeeWebApi.Filters;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthFilter]
    [ServiceFilter(typeof(CustomExceptionFilter))]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1, Name = "Alice Johnson", Salary = 75000, Permanent = true,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Department = new Department { Id = 1, Name = "Engineering" },
                    Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = "ASP.NET Core" } }
                },
                new Employee
                {
                    Id = 2, Name = "Bob Smith", Salary = 60000, Permanent = false,
                    DateOfBirth = new DateTime(1995, 8, 22),
                    Department = new Department { Id = 2, Name = "HR" },
                    Skills = new List<Skill> { new Skill { Id = 3, Name = "Communication" } }
                },
                new Employee
                {
                    Id = 3, Name = "Carol White", Salary = 90000, Permanent = true,
                    DateOfBirth = new DateTime(1985, 3, 10),
                    Department = new Department { Id = 1, Name = "Engineering" },
                    Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" }, new Skill { Id = 4, Name = "Azure" } }
                }
            };
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> GetStandard()
        {
            throw new Exception("Demo exception from GET action to test CustomExceptionFilter.");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> GetById(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null) return NotFound();

            existing.Name = employee.Name;
            existing.Salary = employee.Salary;
            existing.Permanent = employee.Permanent;
            existing.Department = employee.Department;
            existing.Skills = employee.Skills;
            existing.DateOfBirth = employee.DateOfBirth;

            return Ok(existing);
        }
    }
}
