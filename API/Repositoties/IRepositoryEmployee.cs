using System.Collections.Generic;
using System.Threading.Tasks;
using TPApi.Entites;

namespace TPApi.Repositoties
{
    public interface IRepositoryEmployee
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int Id);
        Task<Employee> GetEmployeeByField(int stament, string value);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task UpdateEmployee(int id,Employee employee);
        Task DeleteEmployee(int id);

    }
}