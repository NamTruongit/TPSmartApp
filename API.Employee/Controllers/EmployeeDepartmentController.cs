using EmployeeDataManager.SqlServer.Entities;
using EmployeeDataManager.SqlServer.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDepartmentController : ControllerBase
    {
        private readonly IEmployeeDepartmentRepository _employeeDepartmentRepo;

        public EmployeeDepartmentController(IEmployeeDepartmentRepository employeeDepartmentRepo)
        {
            _employeeDepartmentRepo = employeeDepartmentRepo;
        }

        [HttpGet("{id}", Name = "GetEmployeeDepartmentById")]
        public async Task<ActionResult<EmployeeDepartment>> GetDepartmentById(int id)
        {
            var department = await _employeeDepartmentRepo.GetEmployeeDepartmentID(id);
            return Ok(department);
        }



        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] EmployeeDepartment employeeDepartment)
        {
            var createEmDepartment = await _employeeDepartmentRepo.CreateEmployeeDepartment(employeeDepartment);
            return Ok(createEmDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] EmployeeDepartment employeeDepartment)
        {
            var DbEmployee = await _employeeDepartmentRepo.GetEmployeeDepartmentID(id);
            if (DbEmployee is null)
                return NotFound();
            await _employeeDepartmentRepo.UpdateEmployeeDepartment(id, employeeDepartment);
            return CreatedAtRoute("Department", new { Id = employeeDepartment.Id }, employeeDepartment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var DbEmployee = await _employeeDepartmentRepo.GetEmployeeDepartmentID(id);
            if (DbEmployee is null)
                return NotFound();
            await _employeeDepartmentRepo.DeleteEmployeeDepartment(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var departments = await _employeeDepartmentRepo.GetAllEmployeeDepartment();
            return Ok(departments);
        }
    }
}
