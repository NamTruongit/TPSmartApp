using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.DataManager.SqlServer.Entites;
using Schedule.DataManager.SqlServer.IRepositories;
using System.Threading.Tasks;

namespace API.Schedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerController(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        [HttpGet("{id}", Name = "GetProducerById")]
        public async Task<ActionResult<Producer>> GetProducerById(int id)
        {
            var producer = await _producerRepository.GetProducerByID(id);
            return Ok(producer);
        }

        [HttpGet]
        [Route("/GetProducerByField")]
        public async Task<ActionResult<ConѕignmentDetails>> GetProducerByField(int statement, string value)
        {
            var producer = await _producerRepository.GetProducerByField(statement, value);
            return Ok(producer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducer([FromBody] Producer producer)
        {
            var createProducer = await _producerRepository.CreateProducer(producer);
            return Ok(createProducer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducer(int id, [FromBody] Producer producer)
        {
            var DbProducer = await _producerRepository.GetProducerByID(id);
            if (DbProducer is null)
                return NotFound();
            await _producerRepository.UpdateProducer(id, producer);
            return CreatedAtRoute("Producer", new { Id = producer.Id }, producer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            var DbProducer = await _producerRepository.GetProducerByID(id);
            if (DbProducer is null)
                return NotFound();
            await _producerRepository.DeleteProducer(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducer()
        {
            var producers = await _producerRepository.GetAllProducer();
            return Ok(producers);
        }
    }
}
