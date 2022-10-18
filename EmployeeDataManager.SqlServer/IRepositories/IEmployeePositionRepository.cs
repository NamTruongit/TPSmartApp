using EmployeeDataManager.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.IRepositories
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
