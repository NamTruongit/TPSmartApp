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
    public class CommodityController : ControllerBase
    {
        private readonly ICommodityRepository _commodityRepository;

        public CommodityController(ICommodityRepository commodityRepository)
        {
            _commodityRepository = commodityRepository;
        }

        [HttpGet("{id}", Name = "GetCommodityById")]
        public async Task<ActionResult<Commodity>> GetCommodityById(int id)
        {
            var commodity = await _commodityRepository.GetCommodityByID(id);
            return Ok(commodity);
        }

        [HttpGet]
        [Route("/GetCommodityByField")]
        public async Task<ActionResult<Commodity>> GetCommodityByField(int statement, string value)
        {
            var commodity = await _commodityRepository.GetCommodityByField(statement, value);
            return Ok(commodity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommodity([FromBody] Commodity commodity)
        {
            var createCommodity = await _commodityRepository.CreateCommodity(commodity);
            return Ok(createCommodity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommodity(int id, [FromBody] Commodity commodity)
        {
            var DbCommodity = await _commodityRepository.GetCommodityByID(id);
            if (DbCommodity is null)
                return NotFound();
            await _commodityRepository.UpdateCommodity(id, commodity);
            return CreatedAtRoute("Commodity", new { Id = commodity.Id }, commodity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommodity(int id)
        {
            var DbCommodity = await _commodityRepository.GetCommodityByID(id);
            if (DbCommodity is null)
                return NotFound();
            await _commodityRepository.DeleteCommodity(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var commodities = await _commodityRepository.GetAllCommodity();
            return Ok(commodities);
        }
    }
}
