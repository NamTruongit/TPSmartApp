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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperContext _context;

        public DepartmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            var query = "EXEC Department_Insert @DepartmentName,@Decription,@DepartmentCode";
            var parameters = new DynamicParameters();
            parameters.Add("DepartmentName", department.DeparmentName, DbType.String);
            parameters.Add("Decription", department.Decription, DbType.String);
            parameters.Add("DepartmentCode", department.DepartmentCode, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdDepartment = new Department
                {
                    DeparmentName = department.DeparmentName,
                    Decription = department.Decription,
                    DepartmentCode = department.DepartmentCode,

                };
                return createdDepartment;
            }
        }

        public async Task DeleteDepartment(int id)
        {
            var query = "EXEC Department_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<Department> GeDepartmentByField(int stament, string value)
        {
            var query = "exec Department_SearchByField @Stament , @Value";
            using (var connection = _context.CreateConnection())
            {
                var department = await connection.QueryFirstOrDefaultAsync<Department>(query, new { Stament = stament, Value = value });
                return department;
            }
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            var query = "SELECT * FROM Department";
            using (var connection = _context.CreateConnection())
            {
                var emloyees = await connection.QueryAsync<Department>(query);
                return emloyees.ToList();
            }
        }

        public async Task<Department> GetDepartmentByID(int id)
        {
            var query = "EXEC Department_SearchById @Id";
            using (var connection = _context.CreateConnection())
            {
                var department = await connection.QueryFirstOrDefaultAsync<Department>(query, new { Id = id });
                return department;
            }
        }

        public async Task UpdateDepartment(int id, Department department)
        {
            var query = "EXEC Department_Update @Id,@DepartmentName,@Decription,@DepartmentCode";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("DepartmentName", department.DeparmentName, DbType.String);
            parameters.Add("Decription", department.Decription, DbType.String);
            parameters.Add("DepartmentCode", department.DepartmentCode, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
