using EmployeeDataManager.SqlServer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.Repositories
{
    public class EmployeeDepartmentRepository : IEmployeeDepartmentRepository
    {
        public Task<Entities.EmployeeDepartment> CreateEmployeeDepartment(Entities.EmployeeDepartment employeeDepartment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.EmployeeDepartment> GeEmployeeDepartmentByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entities.EmployeeDepartment>> GetAllEmployeeDepartment()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.EmployeeDepartment> GetEmployeeDepartmentID(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeDepartment(int id, Entities.EmployeeDepartment employeeDepartment)
        {
            throw new NotImplementedException();
        }
    }
}
