using Dapper;
using Schedule.DataManager.SqlServer.Context;
using Schedule.DataManager.SqlServer.Entites;
using Schedule.DataManager.SqlServer.IRepositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.Repositories
{
    public class ConsignmentRepository : IConsignmentRepository
    {
        private readonly DapperContext _context;

        public ConsignmentRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<Conѕignment> CreateConsignment(Conѕignment conѕignment)
        {
            var query = "EXEC Consignment_Insert @ConѕignmentCode,@Decription,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("ConѕignmentCode", conѕignment.ConѕignmentCode, DbType.String);
            parameters.Add("Decription", conѕignment.Decription, DbType.String);
            parameters.Add("UserID", conѕignment.UserID, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdConѕignment = new Conѕignment
                {
                    ConѕignmentCode = conѕignment.ConѕignmentCode,
                    Decription = conѕignment.Decription,
                    UserID = conѕignment.UserID
                };
                return createdConѕignment;
            }
        }

        public async Task DeleteConsignment(int id)
        {
            var query = "EXEC Consignment_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Conѕignment>> GetAllConsignment()
        {
            var query = "SELECT * FROM Conѕignment";
            using (var connection = _context.CreateConnection())
            {
                var conѕignments = await connection.QueryAsync<Conѕignment>(query);
                return conѕignments.ToList();
            }
        }

        public Task<Conѕignment> GetConsignmentByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<Conѕignment> GetConsignmentByID(int id)
        {
            var query = "EXEC Consignment_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var conѕignment = await connection.QueryFirstOrDefaultAsync<Conѕignment>(query, new { Id = id });
                return conѕignment;
            }
        }

        public async Task UpdateConsignment(int id, Conѕignment conѕignment)
        {
            var query = "EXEC Consignment_Update @Id,@ConѕignmentCode,@Decription,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("ConѕignmentCode", conѕignment.ConѕignmentCode, DbType.String);
            parameters.Add("Decription", conѕignment.Decription, DbType.String);
            parameters.Add("UserID", conѕignment.UserID, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
