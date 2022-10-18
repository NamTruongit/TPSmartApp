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
    public class PositionRepository : IPositionRepository
    {
        private readonly DapperContext _context;
        public PositionRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<Position> CreatePosition(Position position)
        {
            var query = "EXEC Position_Insert @PositionName,@Decription,@PositionCode";
            var parameters = new DynamicParameters();
            parameters.Add("PositionName", position.PositionName, DbType.String);
            parameters.Add("Decription", position.Decription, DbType.String);
            parameters.Add("PositionCode", position.PositionCode, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdPosition = new Position
                {
                    PositionName = position.PositionName,
                    Decription = position.Decription,

                };
                return createdPosition;
            }
        }

        public async Task DeletePosition(int id)
        {
            var query = "EXEC Position_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public Task<Position> GePositionByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Position>> GetAllPosition()
        {
            var query = "SELECT * FROM Position";
            using (var connection = _context.CreateConnection())
            {
                var position = await connection.QueryAsync<Position>(query);
                return position.ToList();
            }
        }

        public async Task<Position> GetPositionByID(int id)
        {
            var query = "EXEC Position_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var position = await connection.QueryFirstOrDefaultAsync<Position>(query, new { Id = id });
                return position;
            }
        }

        public async Task UpdatePosition(int id, Position position)
        {
            var query = "EXEC Position_Update @Id,@PositionName,@Decription,@PositionCode";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("PositionName", position.PositionName, DbType.String);
            parameters.Add("Decription", position.Decription, DbType.String);
            parameters.Add("PositionCode", position.PositionCode, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
