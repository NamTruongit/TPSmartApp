using Dapper;
using EmployeeDataManager.SqlServer.Context;
using EmployeeDataManager.SqlServer.Entities;
using EmployeeDataManager.SqlServer.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<Employees> CreateEmployee(Employees employee)
        {
            var query = "EXEC Employee_Insert @FirstName,@LastName,@PhoneNumber,@Address,@DayOfBirth,@NativePlace,@PassWord";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", employee.FirstName, DbType.String);
            parameters.Add("LastName", employee.LastName, DbType.String);
            parameters.Add("PhoneNumber", employee.PhoneNumber, DbType.Int32);
            parameters.Add("Address", employee.Address, DbType.String);
            parameters.Add("DayOfBirth", employee.DayOfBirth, DbType.DateTime);
            parameters.Add("NativePlace", employee.NativePlace, DbType.String);
            parameters.Add("PassWord", employee.PassWord, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdEmployee = new Employees
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
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Employees>> GetAllEmployee()
        {
            var query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var emloyees = await connection.QueryAsync<Employees>(query);
                return emloyees.ToList();
            }
        }

        public async Task<Employees> GetEmployeeByField(int stament, string value)
        {
            var query = "exec Employee_SearchByField @Stament , @Value";
            using (var connection = _context.CreateConnection())
            {
                var emloyee = await connection.QueryFirstOrDefaultAsync<Employees>(query, new { Stament = stament, Value = value });
                return emloyee;
            }
        }

        public async Task<Employees> GetEmployeeById(int Id)
        {
            var query = "EXEC Employee_GetByID @Id";
            using (var connection = _context.CreateConnection())
            {
                var emloyees = await connection.QueryFirstOrDefaultAsync<Employees>(query, new { Id = Id });
                return emloyees;
            }
        }

        public async Task UpdateEmployee(int id, Employees employee)
        {
            var query = "EXEC Employee_Update @Id,@FirstName,@Lastname,@PhoneNumber,@Address,@DayOfBirth,@NativePlace,@PassWord";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Firstname", employee.FirstName, DbType.String);
            parameters.Add("Lastname", employee.LastName, DbType.String);
            parameters.Add("PhoneNumber", employee.PhoneNumber, DbType.Int32);
            parameters.Add("Address", employee.Address, DbType.String);
            parameters.Add("DayOfBirth", employee.DayOfBirth, DbType.DateTime);
            parameters.Add("NativePlace", employee.NativePlace, DbType.String);
            parameters.Add("PassWord", employee.PassWord, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
