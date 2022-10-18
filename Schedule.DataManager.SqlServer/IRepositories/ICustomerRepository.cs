using Schedule.DataManager.SqlServer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> GetCustomerByID(int id);
        Task<Customer> GetCustomerByField(int stament, string value);
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task UpdateCustomer(int id, Customer customer);
        Task DeleteCustomer(int id);
    }
}
