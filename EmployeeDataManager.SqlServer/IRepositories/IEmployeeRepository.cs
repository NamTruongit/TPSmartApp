using EmployeeDataManager.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<Employees> CreateEmployee(Employees employee);
        Task<Employees> GetEmployeeById(int Id);
        Task<Employees> GetEmployeeByField(int stament, string value);
        Task<IEnumerable<Employees>> GetAllEmployee();
        Task UpdateEmployee(int id, Employees employee);
        Task DeleteEmployee(int id);
    }
}
