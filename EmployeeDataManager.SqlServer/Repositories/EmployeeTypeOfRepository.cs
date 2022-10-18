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
    public class EmployeeTypeOfRepository : IEmployeeTypeOfRepository
    {
        private readonly DapperContext _context;

        public EmployeeTypeOfRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<EmployeeTypeOfEmployee> CreateEmloyeeTypeOfEmployee(EmployeeTypeOfEmployee emloyeeTypeOfEmployee)
        {
            var query = "EXEC Emloyee_TypeOfEmployee_Insert @EmployeeId,@TOEmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", emloyeeTypeOfEmployee.EmployeeId, DbType.Int32);
            parameters.Add("TOEmployeeId", emloyeeTypeOfEmployee.TOEmployeeId, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdEmployeePositiom = new EmployeeTypeOfEmployee
                {
                    EmployeeId = emloyeeTypeOfEmployee.EmployeeId,
                    TOEmployeeId = emloyeeTypeOfEmployee.TOEmployeeId,

                };
                return createdEmployeePositiom;
            }
        }

        public async Task DeleteEmloyeeTypeOfEmployee(int id)
        {
            var query = "EXEC Emloyee_TypeOfEmployee_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<EmployeeTypeOfEmployee>> GetAllEmloyeeTypeOfEmployee()
        {
            var query = "Select * from Emloyee_TypeOfEmployee";
            using (var connection = _context.CreateConnection())
            {
                var emloyeeTypeOfEmployee = await connection.QueryAsync<EmployeeTypeOfEmployee>(query);
                return emloyeeTypeOfEmployee.ToList();
            }
        }

        public Task<EmployeeTypeOfEmployee> GetEmloyeeTypeOfEmployeeByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeTypeOfEmployee> GetEmloyeeTypeOfEmployeeByID(int id)
        {
            var query = "EXEC Emloyee_TypeOfEmployee_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var emloyeeTypeOfEmployee = await connection.QueryFirstOrDefaultAsync<EmployeeTypeOfEmployee    >(query, new { Id = id });
                return emloyeeTypeOfEmployee;
            }
        }

        public async Task UpdateEmloyeeTypeOfEmployee(int id, EmployeeTypeOfEmployee emloyeeTypeOfEmployee)
        {
            var query = "EXEC Emloyee_TypeOfEmployee_Update @Id,@EmployeeId,@TOEmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("EmployeeId", emloyeeTypeOfEmployee.EmployeeId, DbType.Int32);
            parameters.Add("TOEmployeeId", emloyeeTypeOfEmployee.TOEmployeeId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
