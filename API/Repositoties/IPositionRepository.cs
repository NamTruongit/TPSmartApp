using System.Collections.Generic;
using System.Threading.Tasks;
using TPApi.Entites;

namespace TPApi.Repositoties
{
    public interface IPositionRepository
    {
        Task<Position> CreatePosition(Position position);
        Task<Position> GetPositionByID(int id);
        Task<Position> GePositionByField(int stament, string value);
        Task<IEnumerable<Position>> GetAllPosition();
        Task UpdatePosition(int id, Position position);
        Task DeletePosition(int id);
    }
}
