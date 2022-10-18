using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.DataManager.SqlServer.Entites;
using Schedule.DataManager.SqlServer.IRepositories;
using System.Threading.Tasks;

namespace API.Schedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConѕignmentDetailController : ControllerBase
    {
        private readonly IConsignmentDetailRepository _consignmentDetailRepo;

        public ConѕignmentDetailController(IConsignmentDetailRepository consignmentDetailRepo)
        {
            _consignmentDetailRepo = consignmentDetailRepo;
        }

        [HttpGet("{id}", Name = "GetConsignmentDetailById")]
        public async Task<ActionResult<ConѕignmentDetails>> GetConsignmentDetailById(int id)
        {
            var producer = await _consignmentDetailRepo.GetConѕignmentDetailByID(id);
            return Ok(producer);
        }

        [HttpGet]
        [Route("/GetConsignmentDetailByField")]
        public async Task<ActionResult<ConѕignmentDetails>> GetConsignmentDetailByField(int statement, string value)
        {
            var producer = await _consignmentDetailRepo.GetConѕignmentDetailByField(statement, value);
            return Ok(producer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConsignmentDetail([FromBody] ConѕignmentDetails consignmentDetail)
        {
            var createProducer = await _consignmentDetailRepo.CreateConѕignmentDetail(consignmentDetail);
            return Ok(createProducer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConsignmentDetail(int id, [FromBody] ConѕignmentDetails consignmentDetail)
        {
            var DbConѕignmentDetail = await _consignmentDetailRepo.GetConѕignmentDetailByID(id);
            if (DbConѕignmentDetail is null)
                return NotFound();
            await _consignmentDetailRepo.UpdateConѕignmentDetail(id, consignmentDetail);
            return CreatedAtRoute("ConѕignmentDetail", new { Id = consignmentDetail.Id }, consignmentDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsignmentDetail(int id)
        {
            var DbConѕignmentDetail = await _consignmentDetailRepo.GetConѕignmentDetailByID(id);
            if (DbConѕignmentDetail is null)
                return NotFound();
            await _consignmentDetailRepo.DeleteConѕignmentDetail(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConsignmentDetail()
        {
            var consignmentDetails = await _consignmentDetailRepo.GetAllConѕignmentDetail();
            return Ok(consignmentDetails);
        }
    }
}
