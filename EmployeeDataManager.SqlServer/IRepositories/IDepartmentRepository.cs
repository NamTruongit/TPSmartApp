using EmployeeDataManager.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.IRepositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartment(Department department);
        Task<Department> GetDepartmentByID(int id);
        Task<Department> GeDepartmentByField(int stament, string value);
        Task<IEnumerable<Department>> GetAllDepartment();
        Task UpdateDepartment(int id, Department department);
        Task DeleteDepartment(int id);
    }
}
