using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TPApi.Context;
using TPApi.Entites;

namespace TPApi.Repositoties
{
    public class EmployeePositionRepository : IEmployeePositionRepository
    {
        private readonly DapperContext _context;

        public EmployeePositionRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<EmployeePosition> CreateEmployeePosition(EmployeePosition employeePosition)
        {
            var query = "EXEC EmployeePositon_Insert @EmployeeId,@PositionId";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", employeePosition.EmployeeId, DbType.Int32);
            parameters.Add("PositionId", employeePosition.PositionId, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdEmployeePositiom = new EmployeePosition
                {
                    EmployeeId = employeePosition.EmployeeId,
                    PositionId = employeePosition.PositionId,

                };
                return createdEmployeePositiom;
            }
        }

        public async Task DeleteEmployeePosition(int id)
        {
            var query = "EXEC EmployeePositon_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public Task<EmployeePosition> GetEmployeePositionByField(int stament, string value)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<EmployeePosition>> GetAllEmployeePosition()
        {
            var query = "Select * from EmployeePositon";
            using (var connection = _context.CreateConnection())
            {
                var employeePosition = await connection.QueryAsync<EmployeePosition>(query);
                return employeePosition.ToList();
            }
        }

        public async Task<EmployeePosition> GetEmployeePositionByID(int id)
        {
            var query = "EXEC  EmployeePositon_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var employeePosition = await connection.QueryFirstOrDefaultAsync<EmployeePosition>(query, new { Id = id });
                return employeePosition;
            }
        }

        public async Task UpdateEmployeePosition(int id, EmployeePosition employeePosition)
        {
            var query = "EXEC EmployeePositon_Update @Id,@EmployeeId,@PositionId";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("EmployeeId", employeePosition.EmployeeId, DbType.Int32);
            parameters.Add("PositionId", employeePosition.PositionId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
