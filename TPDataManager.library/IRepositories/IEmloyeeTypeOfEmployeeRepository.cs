using System.Collections.Generic;
using System.Threading.Tasks;
using TPApi.Entites;

namespace TPDataManager.library.IRepositories
{
    public interface IEmloyeeTypeOfEmployeeRepository
    {
        Task<EmloyeeTypeOfEmployee> CreateEmloyeeTypeOfEmployee(EmloyeeTypeOfEmployee emloyeeTypeOfEmployee);
        Task DeleteEmloyeeTypeOfEmployee(int id);
        Task<IEnumerable<EmloyeeTypeOfEmployee>> GetAllEmloyeeTypeOfEmployee();
        Task<EmloyeeTypeOfEmployee> GetEmloyeeTypeOfEmployeeByField(int stament, string value);
        Task<EmloyeeTypeOfEmployee> GetEmloyeeTypeOfEmployeeByID(int id);
        Task UpdateEmloyeeTypeOfEmployee(int id, EmloyeeTypeOfEmployee emloyeeTypeOfEmployee);
    }
}