using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TPApi.Context;
using TPApi.Entites;
using TPDataManager.library.IRepositories;

namespace TPApi.Repositoties
{
    public class EmployeeDepartmentRepositoty : IEmployeeDepartmentRepositoty
    {
        private readonly DapperContext _context;

        public EmployeeDepartmentRepositoty(DapperContext context)
        {
            _context = context;
        }
        public async Task<EmployeeDepartment> CreateEmployeeDepartment(EmployeeDepartment employeeDepartment)
        {
            var query = "EXEC EmployeeDepartment_Insert @EmployeeId,@DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", employeeDepartment.EmployeeId, DbType.Int32);
            parameters.Add("DepartmentId", employeeDepartment.DepartmentId, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdEmployeeDepartment = new EmployeeDepartment
                {
                    EmployeeId = employeeDepartment.EmployeeId,
                    DepartmentId = employeeDepartment.DepartmentId,

                };
                return createdEmployeeDepartment;
            }
        }

        public async Task DeleteEmployeeDepartment(int id)
        {
            var query = "EXEC EmployeeDepartment_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public Task<EmployeeDepartment> GeEmployeeDepartmentByField(int stament, string value)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeDepartment>> GetAllEmployeeDepartment()
        {
            var query = "Select * from EmployeeDepartment";
            using (var connection = _context.CreateConnection())
            {
                var employeeDepartment = await connection.QueryAsync<EmployeeDepartment>(query);
                return employeeDepartment.ToList();
            }
        }

        public async Task<EmployeeDepartment> GetEmployeeDepartmentID(int id)
        {
            var query = "EXEC  EmployeeDepartment_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var employeeDepartment = await connection.QueryFirstOrDefaultAsync<EmployeeDepartment>(query, new { Id = id });
                return employeeDepartment;
            }
        }

        public async Task UpdateEmployeeDepartment(int id, EmployeeDepartment employeeDepartment)
        {
            var query = "EXEC EmployeeDepartment_Update @Id,@EmployeeId,@DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("EmployeeId", employeeDepartment.EmployeeId, DbType.Int32);
            parameters.Add("DepartmentId", employeeDepartment.DepartmentId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
