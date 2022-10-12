using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TPApi.Entites;
using TPApi.Repositoties;

namespace TPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePositionController : ControllerBase
    {
        private readonly IEmployeePositionRepository _employeePositionRepo;

        public EmployeePositionController(IEmployeePositionRepository employeePositionRepo)
        {
            _employeePositionRepo = employeePositionRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] EmployeePosition employeePosition)
        {
            var createEmployeePosition = await _employeePositionRepo.CreateEmployeePosition(employeePosition);
            return Ok(createEmployeePosition);
        }

        [HttpGet("{id}", Name = "GetEmployeePositionById")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var createEmployeePosition = await _employeePositionRepo.GetEmployeePositionByID(id);
            return Ok(createEmployeePosition);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var createEmployeePosition = await _employeePositionRepo.GetAllEmployeePosition();
            return Ok(createEmployeePosition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] EmployeePosition employeePosition)
        {
            var DbEmployeePosition = await _employeePositionRepo.GetEmployeePositionByID(id);
            if (DbEmployeePosition is null)
                return NotFound();
            await _employeePositionRepo.UpdateEmployeePosition(id, employeePosition);
            return CreatedAtRoute("Department", new { Id = employeePosition.Id }, employeePosition);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var DbEmployeePosition = await _employeePositionRepo.GetEmployeePositionByID(id);
            if (DbEmployeePosition is null)
                return NotFound();
            await _employeePositionRepo.DeleteEmployeePosition(id);
            return Ok();
        }
    }
}
