using Microsoft.AspNetCore.Mvc;
using Schedule.DataManager.SqlServer.Entites;
using Schedule.DataManager.SqlServer.IRepositories;
using System.Threading.Tasks;

namespace API.Schedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet("{id}", Name = "GetDepartmentById")]
        public async Task<ActionResult<Customer>> GetDepartmentById(int id)
        {
            var department = await _customerRepository.GetCustomerByID(id);
            return Ok(department);
        }

        [HttpGet]
        [Route("/GetCustomerByField")]
        public async Task<ActionResult<Customer>> GetDepartmentByField(int statement, string value)
        {
            var customer = await _customerRepository.GetCustomerByField(statement, value);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Customer customer)
        {
            var createCustomer = await _customerRepository.CreateCustomer(customer);
            return Ok(createCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] Customer customer)
        {
            var DbCustomer = await _customerRepository.GetCustomerByID(id);
            if (DbCustomer is null)
                return NotFound();
            await _customerRepository.UpdateCustomer(id, customer);
            return CreatedAtRoute("Customer", new { Id = customer.Id }, customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var DbCustomer = await _customerRepository.GetCustomerByID(id);
            if (DbCustomer is null)
                return NotFound();
            await _customerRepository.DeleteCustomer(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customers = await _customerRepository.GetAllCustomer();
            return Ok(customers);
        }
    }
}
