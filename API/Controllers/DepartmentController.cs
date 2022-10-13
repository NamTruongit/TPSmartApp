using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TPApi.Entites;
using TPDataManager.library.IRepositories;

namespace TPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("{id}", Name = "GetDepartmentById")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetDepartmentByID(id);
            return Ok(department);
        }

        [HttpGet]
        [Route("/GetDepartmentByField")]
        public async Task<ActionResult<Department>> GetDepartmentByField(int statement, string value)
        {
            var department = await _departmentRepository.GeDepartmentByField(statement, value);
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            var createDepartment = await _departmentRepository.CreateDepartment(department);
            return Ok(createDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] Department department)
        {
            var DbEmployee = await _departmentRepository.GetDepartmentByID(id);
            if (DbEmployee is null)
                return NotFound();
            await _departmentRepository.UpdateDepartment(id, department);
            return CreatedAtRoute("Department", new { Id = department.Id }, department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var DbEmployee = await _departmentRepository.GetDepartmentByID(id);
            if (DbEmployee is null)
                return NotFound();
            await _departmentRepository.DeleteDepartment(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var departments = await _departmentRepository.GetAllDepartment();
            return Ok(departments);
        }
    }
}