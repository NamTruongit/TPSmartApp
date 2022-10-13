using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TPApi.Entites;
using TPDataManager.library.IRepositories;

namespace TPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfEmployeeController : ControllerBase
    {
        private readonly ITypeOfEmployeeRepository _typeOfEmployeeRepo;

        public TypeOfEmployeeController(ITypeOfEmployeeRepository typeOfEmployeeRepo)
        {
            _typeOfEmployeeRepo = typeOfEmployeeRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] TypeOfEmployee typeOfEmployee)
        {
            var createTypeOfEmployee = await _typeOfEmployeeRepo.CreateTypeOfEmployee(typeOfEmployee);
            return Ok(createTypeOfEmployee);
        }

        [HttpGet("{id}", Name = "GetTypeOfEmployeeById")]
        public async Task<ActionResult<TypeOfEmployee>> GetDepartmentById(int id)
        {
            var createTypeOfEmployee = await _typeOfEmployeeRepo.GetTypeOfEmployeeByID(id);
            return Ok(createTypeOfEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var typeOfEmployee = await _typeOfEmployeeRepo.GetAllTypeOfEmployee();
            return Ok(typeOfEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] TypeOfEmployee typeOfEmployee)
        {
            var DbEmployeePosition = await _typeOfEmployeeRepo.GetTypeOfEmployeeByID(id);
            if (DbEmployeePosition is null)
                return NotFound();
            await _typeOfEmployeeRepo.UpdateTypeOfEmployee(id, typeOfEmployee);
            return CreatedAtRoute("TypeOfEmployee", new { Id = typeOfEmployee.Id }, typeOfEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var DbEmployeePosition = await _typeOfEmployeeRepo.GetTypeOfEmployeeByID(id);
            if (DbEmployeePosition is null)
                return NotFound();
            await _typeOfEmployeeRepo.DeleteTypeOfEmployee(id);
            return Ok();
        }
    }
}
