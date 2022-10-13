using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TPApi.Entites;
using TPDataManager.library.IRepositories;

namespace TPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmloyeeTypeOfEmployeeController : ControllerBase
    {
        private readonly IEmloyeeTypeOfEmployeeRepository _emloyeeTypeOfEmployee;

        public EmloyeeTypeOfEmployeeController(IEmloyeeTypeOfEmployeeRepository emloyeeTypeOfEmployee)
        {
            _emloyeeTypeOfEmployee = emloyeeTypeOfEmployee;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] EmloyeeTypeOfEmployee emloyeeTypeOfEmployee)
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
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] EmloyeeTypeOfEmployee emloyeeTypeOfEmployee)
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
