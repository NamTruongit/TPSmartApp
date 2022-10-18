using EmployeeDataManager.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.IRepositories
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
