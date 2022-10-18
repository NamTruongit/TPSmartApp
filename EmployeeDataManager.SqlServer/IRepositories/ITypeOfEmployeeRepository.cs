using EmployeeDataManager.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.IRepositories
{
    public interface ITypeOfEmployeeRepository
    {
        Task<TypeOfEmployee> CreateTypeOfEmployee(TypeOfEmployee typeOfEmployee);
        Task DeleteTypeOfEmployee(int id);
        Task<IEnumerable<TypeOfEmployee>> GetAllTypeOfEmployee();
        Task<TypeOfEmployee> GetTypeOfEmployeeByField(int stament, string value);
        Task<TypeOfEmployee> GetTypeOfEmployeeByID(int id);
        Task UpdateTypeOfEmployee(int id, TypeOfEmployee typeOfEmployee);
    }
}
