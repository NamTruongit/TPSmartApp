using EmployeeDataManager.SqlServer.Entities;
using EmployeeDataManager.SqlServer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.Repositories
{
    public class TypeOfEmployeeRepository : ITypeOfEmployeeRepository
    {
        public Task<TypeOfEmployee> CreateTypeOfEmployee(TypeOfEmployee typeOfEmployee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTypeOfEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeOfEmployee>> GetAllTypeOfEmployee()
        {
            throw new NotImplementedException();
        }

        public Task<TypeOfEmployee> GetTypeOfEmployeeByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public Task<TypeOfEmployee> GetTypeOfEmployeeByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTypeOfEmployee(int id, TypeOfEmployee typeOfEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
