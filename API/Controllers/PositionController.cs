using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TPApi.Entites;
using TPApi.Repositoties;

namespace TPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository _positionRepository;

        public PositionController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosotion([FromBody] Position position)
        {
            var createPositionn = await _positionRepository.CreatePosition(position);
            return Ok(createPositionn);
        }

        [HttpGet("{id}", Name = "GetPosotionById")]
        public async Task<ActionResult<Position>> GetDepartmentById(int id)
        {
            var position = await _positionRepository.GetPositionByID(id);
            return Ok(position);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var DbEmployee = await _positionRepository.GetPositionByID(id);
            if (DbEmployee is null)
                return NotFound();
            await _positionRepository.DeletePosition(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var positon = await _positionRepository.GetAllPosition();
            return Ok(positon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] Position position)
        {
            var DbEmployee = await _positionRepository.GetPositionByID(id);
            if (DbEmployee is null)
                return NotFound();
            await _positionRepository.UpdatePosition(id, position);
            return CreatedAtRoute("Department", new { Id = position.Id }, position);
        }
    }
}
