using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TPApi.Entites;
using TPDataManager.library.IRepositories;

namespace TPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryEmployee _repositoryEmployee;

        public EmployeeController(IRepositoryEmployee repositoryEmployee)
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
        public async Task<ActionResult<Employee>> GetEmployeeById(int Id)
        {
            var employee = await _repositoryEmployee.GetEmployeeById(Id);
            return Ok(employee);
        }

        [HttpGet]
        [Route("/GetByField")]
        [AllowAnonymous]
        public async Task<ActionResult<Employee>> GetEmployeeByField(int statement,string value)
        {
            var employee = await _repositoryEmployee.GetEmployeeByField(statement,value);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody]Employee employee)
        {
            var createEmployee = await _repositoryEmployee.CreateEmployee(employee);
            return Ok(createEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var DbEmployee = await _repositoryEmployee.GetEmployeeById(id);
            if (DbEmployee is null)
                return NotFound();
            await _repositoryEmployee.UpdateEmployee(id, employee);
            return CreatedAtRoute("Employee",new {Id = employee.Id},employee);
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
