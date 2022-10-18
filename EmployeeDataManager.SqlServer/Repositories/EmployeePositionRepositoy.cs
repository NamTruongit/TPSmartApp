using Dapper;
using EmployeeDataManager.SqlServer.Context;
using EmployeeDataManager.SqlServer.Entities;
using EmployeeDataManager.SqlServer.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.Repositories
{
    public class EmployeePositionRepositoy : IEmployeePositionRepository
    {
        private readonly DapperContext _context;

        public EmployeePositionRepositoy(DapperContext context)
        {
            _context = context;
        }
        public async Task<Entities.EmployeePosition> CreateEmployeePosition(Entities.EmployeePosition employeePosition)
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

        public async Task<IEnumerable<Entities.EmployeePosition>> GetAllEmployeePosition()
        {
            var query = "Select * from EmployeePositon";
            using (var connection = _context.CreateConnection())
            {
                var employeePosition = await connection.QueryAsync<EmployeePosition>(query);
                return employeePosition.ToList();
            }
        }

        public Task<Entities.EmployeePosition> GetEmployeePositionByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.EmployeePosition> GetEmployeePositionByID(int id)
        {
            var query = "EXEC  EmployeePositon_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var employeePosition = await connection.QueryFirstOrDefaultAsync<EmployeePosition>(query, new { Id = id });
                return employeePosition;
            }
        }

        public async Task UpdateEmployeePosition(int id, Entities.EmployeePosition employeePosition)
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
