using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using TPApi.Entites;
using System.Data.SqlClient;
using Dapper;
using TPApi.Context;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TPDataManager.library.IRepositories;

namespace TPApi.Repositoties
{
    public class RepositoryEmployee : IRepositoryEmployee
    {
        private readonly DapperContext _contex;
        public RepositoryEmployee(DapperContext context) => _contex = context;

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var query = "EXEC Employee_Insert @FirstName,@LastName,@PhoneNumber,@Address,@DayOfBirth,@NativePlace,@PassWord";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", employee.FirstName,DbType.String);
            parameters.Add("LastName", employee.LastName, DbType.String);
            parameters.Add("PhoneNumber", employee.PhoneNumber, DbType.Int32);
            parameters.Add("Address", employee.Address, DbType.String);
            parameters.Add("DayOfBirth", employee.DayOfBirth, DbType.DateTime);
            parameters.Add("NativePlace", employee.NativePlace, DbType.String);
            parameters.Add("PassWord", employee.PassWord, DbType.String);


            using (var connection = _contex.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdEmployee = new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address = employee.Address,
                    DayOfBirth = employee.DayOfBirth,
                    NativePlace = employee.NativePlace,
                    PhoneNumber = employee.PhoneNumber,
                    PassWord = employee.PassWord
                };
                return createdEmployee;
            }
        }

        public async Task DeleteEmployee(int id)
        {
            var query = "EXEC Employee_Delete @Id";
            using (var connection = _contex.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            var query = "SELECT * FROM Employee";
            using (var connection = _contex.CreateConnection())
            {
                var emloyees = await connection.QueryAsync<Employee>(query);
                return emloyees.ToList();
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var query = "EXEC Employee_GetByID @Id";
            using (var connection = _contex.CreateConnection())
            {
                var emloyees= await connection.QueryFirstOrDefaultAsync<Employee>(query,new {Id = id});
                return emloyees;
            }
        }

        public async Task<Employee> GetEmployeeByField(int stament,string value)
        {
            var query = "exec Employee_SearchByField @Stament , @Value";
            using (var connection = _contex.CreateConnection())
            {
                var emloyee = await connection.QueryFirstOrDefaultAsync<Employee>(query, new {Stament = stament,Value=value});  
                return emloyee;
            }
        }

        public async Task UpdateEmployee(int id, Employee employee)
        {
            var query = "EXEC Employee_Update @Id,@FirstName,@Lastname,@PhoneNumber,@Address,@DayOfBirth,@NativePlace,@PassWord";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id,DbType.Int32);
            parameters.Add("Firstname", employee.FirstName, DbType.String);
            parameters.Add("Lastname", employee.LastName, DbType.String);
            parameters.Add("PhoneNumber", employee.PhoneNumber, DbType.Int32);
            parameters.Add("Address", employee.Address, DbType.String);
            parameters.Add("DayOfBirth", employee.DayOfBirth, DbType.DateTime);
            parameters.Add("NativePlace", employee.NativePlace, DbType.String);
            parameters.Add("PassWord", employee.PassWord, DbType.String);

            using (var connection =_contex.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
