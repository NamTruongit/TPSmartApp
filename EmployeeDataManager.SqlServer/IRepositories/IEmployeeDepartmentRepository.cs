using EmployeeDataManager.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.IRepositories
{
    public interface IEmployeeDepartmentRepository
    {
        Task<EmployeeDepartment> CreateEmployeeDepartment(EmployeeDepartment employeeDepartment);
        Task<EmployeeDepartment> GetEmployeeDepartmentID(int id);
        Task<EmployeeDepartment> GeEmployeeDepartmentByField(int stament, string value);
        Task<IEnumerable<EmployeeDepartment>> GetAllEmployeeDepartment();
        Task UpdateEmployeeDepartment(int id, EmployeeDepartment employeeDepartment);
        Task DeleteEmployeeDepartment(int id);
    }
}
