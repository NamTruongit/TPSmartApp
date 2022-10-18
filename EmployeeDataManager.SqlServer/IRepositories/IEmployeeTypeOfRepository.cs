using EmployeeDataManager.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.IRepositories
{
    public interface IEmployeeTypeOfRepository
    {
        Task<EmployeeTypeOfEmployee> CreateEmloyeeTypeOfEmployee(EmployeeTypeOfEmployee emloyeeTypeOfEmployee);
        Task DeleteEmloyeeTypeOfEmployee(int id);
        Task<IEnumerable<EmployeeTypeOfEmployee>> GetAllEmloyeeTypeOfEmployee();
        Task<EmployeeTypeOfEmployee> GetEmloyeeTypeOfEmployeeByField(int stament, string value);
        Task<EmployeeTypeOfEmployee> GetEmloyeeTypeOfEmployeeByID(int id);
        Task UpdateEmloyeeTypeOfEmployee(int id, EmployeeTypeOfEmployee emloyeeTypeOfEmployee);
    }
}
