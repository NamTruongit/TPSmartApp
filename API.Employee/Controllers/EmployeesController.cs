using EmployeeDataManager.SqlServer.Entities;
using EmployeeDataManager.SqlServer.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repositoryEmployee;

        public EmployeesController(IEmployeeRepository repositoryEmployee)
        {
            _repositoryEmployee = repositoryEmployee;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await _repositoryEmployee.GetAllEmployee();
            return Ok(employees);
        }


        [HttpGet("{Id}", Name = "EmployeeById")]
        [AllowAnonymous]
        public async Task<ActionResult<Employees>> GetEmployeeById(int Id)
        {
            var employee = await _repositoryEmployee.GetEmployeeById(Id);
            return Ok(employee);
        }

        [HttpGet]
        [Route("/GetByField")]
        [AllowAnonymous]
        public async Task<ActionResult<Employees>> GetEmployeeByField(int statement, string value)
        {
            var employee = await _repositoryEmployee.GetEmployeeByField(statement, value);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Employees employee)
        {
            var createEmployee = await _repositoryEmployee.CreateEmployee(employee);
            return Ok(createEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employees employee)
        {
            var DbEmployee = await _repositoryEmployee.GetEmployeeById(id);
            if (DbEmployee is null)
                return NotFound();
            await _repositoryEmployee.UpdateEmployee(id, employee);
            return CreatedAtRoute("Employee", new { Id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var DbEmployee = await _repositoryEmployee.GetEmployeeById(id);
            if (DbEmployee is null)
                return NotFound();
            await _repositoryEmployee.DeleteEmployee(id);
            return Ok();
        }
    }
}
