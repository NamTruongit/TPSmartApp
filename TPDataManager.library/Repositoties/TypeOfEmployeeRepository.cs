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
    public class TypeOfEmployeeRepository : ITypeOfEmployeeRepository
    {
        private readonly DapperContext _context;

        public TypeOfEmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<TypeOfEmployee> CreateTypeOfEmployee(TypeOfEmployee typeOfEmployee)
        {
            var query = "EXEC TypeOfEmployee_Insert @TypeOfEmployeeName,@Decription";
            var parameters = new DynamicParameters();
            parameters.Add("TypeOfEmployeeName", typeOfEmployee.TypeOfEmployeeName, DbType.String);
            parameters.Add("Decription", typeOfEmployee.Decription, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdEmployeePositiom = new TypeOfEmployee
                {
                    TypeOfEmployeeName = typeOfEmployee.TypeOfEmployeeName,
                    Decription = typeOfEmployee.Decription,

                };
                return createdEmployeePositiom;
            }
        }

        public Task<TypeOfEmployee> GetTypeOfEmployeeByField(int stament, string value)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TypeOfEmployee>> GetAllTypeOfEmployee()
        {
            var query = "Select * from TypeOfEmployee";
            using (var connection = _context.CreateConnection())
            {
                var employeePosition = await connection.QueryAsync<TypeOfEmployee>(query);
                return employeePosition.ToList();
            }
        }

        public async Task<TypeOfEmployee> GetTypeOfEmployeeByID(int id)
        {
            var query = "EXEC TypeOfEmployee_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var employeePosition = await connection.QueryFirstOrDefaultAsync<TypeOfEmployee>(query, new { Id = id });
                return employeePosition;
            }
        }

        public async Task UpdateTypeOfEmployee(int id, TypeOfEmployee typeOfEmployee)
        {
            var query = "EXEC TypeOfEmployee_Update @Id,@TypeOfEmployeeName,@Decription";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("TypeOfEmployeeName", typeOfEmployee.TypeOfEmployeeName, DbType.String);
            parameters.Add("Decription", typeOfEmployee.Decription, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteTypeOfEmployee(int id)
        {
            var query = "EXEC TypeOfEmployee_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
