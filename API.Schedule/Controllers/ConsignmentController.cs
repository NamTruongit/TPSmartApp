using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.DataManager.SqlServer.Entites;
using Schedule.DataManager.SqlServer.IRepositories;
using Schedule.DataManager.SqlServer.Repositories;
using System.Threading.Tasks;

namespace API.Schedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsignmentController : ControllerBase
    {
        private readonly IConsignmentRepository _consignmentRepository;

        public ConsignmentController(IConsignmentRepository consignmentRepository)
        {
            _consignmentRepository = consignmentRepository;
        }
        [HttpGet("{id}", Name = "GetConsignmentById")]
        public async Task<ActionResult<Commodity>> GetConsignmentById(int id)
        {
            var commodity = await _consignmentRepository.GetConsignmentByID(id);
            return Ok(commodity);
        }

        [HttpGet]
        [Route("/GetConsignmentByField")]
        public async Task<ActionResult<Commodity>> GetConsignmentByField(int statement, string value)
        {
            var commodity = await _consignmentRepository.GetConsignmentByField(statement, value);
            return Ok(commodity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConѕignment([FromBody] Conѕignment consignment)
        {
            var createConsignment = await _consignmentRepository.CreateConsignment(consignment);
            return Ok(createConsignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConѕignment(int id, [FromBody] Conѕignment consignment)
        {
            var DbConsignment = await _consignmentRepository.GetConsignmentByID(id);
            if (DbConsignment is null)
                return NotFound();
            await _consignmentRepository.UpdateConsignment(id, consignment);
            return CreatedAtRoute("Conѕignment", new { Id = consignment.Id }, consignment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConѕignment(int id)
        {
            var DbCustomer = await _consignmentRepository.GetConsignmentByID(id);
            if (DbCustomer is null)
                return NotFound();
            await _consignmentRepository.DeleteConsignment(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConsignment()
        {
            var consignments = await _consignmentRepository.GetAllConsignment();
            return Ok(consignments);
        }
    }
}
