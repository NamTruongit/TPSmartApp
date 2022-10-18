using EmployeeDataManager.SqlServer.Entities;
using EmployeeDataManager.SqlServer.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeOfController : ControllerBase
    {
        private readonly IEmployeeTypeOfRepository _emloyeeTypeOfEmployee;

        public EmployeeTypeOfController(IEmployeeTypeOfRepository employeeTypeOf)
        {
            _emloyeeTypeOfEmployee = employeeTypeOf;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] EmployeeTypeOfEmployee emloyeeTypeOfEmployee)
        {
            var createEmloyeeTypeOfEmployee = await _emloyeeTypeOfEmployee.CreateEmloyeeTypeOfEmployee(emloyeeTypeOfEmployee);
            return Ok(createEmloyeeTypeOfEmployee);
        }

        [HttpGet("{id}", Name = "GetEmloyeeTypeOfEmployeeById")]
        public async Task<ActionResult<TypeOfEmployee>> GetEmloyeeTypeOfEmployeeById(int id)
        {
            var createEmloyeeTypeOfEmployee = await _emloyeeTypeOfEmployee.GetEmloyeeTypeOfEmployeeByID(id);
            return Ok(createEmloyeeTypeOfEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmloyeeTypeOfEmployee()
        {
            var emloyeeTypeOfEmployees = await _emloyeeTypeOfEmployee.GetAllEmloyeeTypeOfEmployee();
            return Ok(emloyeeTypeOfEmployees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] EmployeeTypeOfEmployee emloyeeTypeOfEmployee)
        {
            var DbEmployeePosition = await _emloyeeTypeOfEmployee.GetEmloyeeTypeOfEmployeeByID(id);
            if (DbEmployeePosition is null)
                return NotFound();
            await _emloyeeTypeOfEmployee.UpdateEmloyeeTypeOfEmployee(id, emloyeeTypeOfEmployee);
            return CreatedAtRoute("EmloyeeTypeOfEmployee", new { Id = emloyeeTypeOfEmployee.Id }, emloyeeTypeOfEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmloyeeTypeOfEmployee(int id)
        {
            var DbEmployeePosition = await _emloyeeTypeOfEmployee.GetEmloyeeTypeOfEmployeeByID(id);
            if (DbEmployeePosition is null)
                return NotFound();
            await _emloyeeTypeOfEmployee.DeleteEmloyeeTypeOfEmployee(id);
            return Ok();
        }
    }
}
