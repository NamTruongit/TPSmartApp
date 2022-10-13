using System.Collections.Generic;
using System.Threading.Tasks;
using TPApi.Entites;

namespace TPDataManager.library.IRepositories
{
    public interface IEmployeePositionRepository
    {
        Task<EmployeePosition> CreateEmployeePosition(EmployeePosition employeePosition);
        Task DeleteEmployeePosition(int id);
        Task<IEnumerable<EmployeePosition>> GetAllEmployeePosition();
        Task<EmployeePosition> GetEmployeePositionByField(int stament, string value);
        Task<EmployeePosition> GetEmployeePositionByID(int id);
        Task UpdateEmployeePosition(int id, EmployeePosition employeePosition);
    }
}