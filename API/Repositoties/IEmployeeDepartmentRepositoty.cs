using System.Collections.Generic;
using System.Threading.Tasks;
using TPApi.Entites;

namespace TPApi.Repositoties
{
    public interface IEmployeeDepartmentRepositoty
    {
        Task<EmployeeDepartment> CreateEmployeeDepartment(EmployeeDepartment employeeDepartment);
        Task<EmployeeDepartment> GetEmployeeDepartmentID(int id);
        Task<EmployeeDepartment> GeEmployeeDepartmentByField(int stament, string value);
        Task<IEnumerable<EmployeeDepartment>> GetAllEmployeeDepartment();
        Task UpdateEmployeeDepartment(int id, EmployeeDepartment employeeDepartment);
        Task DeleteEmployeeDepartment(int id);
    }
}
