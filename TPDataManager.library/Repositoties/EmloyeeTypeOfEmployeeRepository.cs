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
    public class EmloyeeTypeOfEmployeeRepository : IEmloyeeTypeOfEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmloyeeTypeOfEmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<EmloyeeTypeOfEmployee> CreateEmloyeeTypeOfEmployee(EmloyeeTypeOfEmployee emloyeeTypeOfEmployee)
        {
            var query = "EXEC Emloyee_TypeOfEmployee_Insert @EmployeeId,@TOEmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", emloyeeTypeOfEmployee.EmployeeId, DbType.Int32);
            parameters.Add("TOEmployeeId", emloyeeTypeOfEmployee.TOEmployeeId, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdEmployeePositiom = new EmloyeeTypeOfEmployee
                {
                    EmployeeId = emloyeeTypeOfEmployee.EmployeeId,
                    TOEmployeeId = emloyeeTypeOfEmployee.TOEmployeeId,

                };
                return createdEmployeePositiom;
            }
        }

        public Task<EmloyeeTypeOfEmployee> GetEmloyeeTypeOfEmployeeByField(int stament, string value)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<EmloyeeTypeOfEmployee>> GetAllEmloyeeTypeOfEmployee()
        {
            var query = "Select * from Emloyee_TypeOfEmployee";
            using (var connection = _context.CreateConnection())
            {
                var emloyeeTypeOfEmployee = await connection.QueryAsync<EmloyeeTypeOfEmployee>(query);
                return emloyeeTypeOfEmployee.ToList();
            }
        }

        public async Task<EmloyeeTypeOfEmployee> GetEmloyeeTypeOfEmployeeByID(int id)
        {
            var query = "EXEC Emloyee_TypeOfEmployee_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var emloyeeTypeOfEmployee = await connection.QueryFirstOrDefaultAsync<EmloyeeTypeOfEmployee>(query, new { Id = id });
                return emloyeeTypeOfEmployee;
            }
        }

        public async Task UpdateEmloyeeTypeOfEmployee(int id, EmloyeeTypeOfEmployee emloyeeTypeOfEmployee)
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

        public async Task DeleteEmloyeeTypeOfEmployee(int id)
        {
            var query = "EXEC Emloyee_TypeOfEmployee_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
