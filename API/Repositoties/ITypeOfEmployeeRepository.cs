using System.Collections.Generic;
using System.Threading.Tasks;
using TPApi.Entites;

namespace TPApi.Repositoties
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