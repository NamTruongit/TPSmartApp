using System.Collections.Generic;
using System.Threading.Tasks;
using TPApi.Entites;

namespace TPApi.Repositoties
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