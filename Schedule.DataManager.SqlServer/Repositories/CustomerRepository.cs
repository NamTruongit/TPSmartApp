using Dapper;
using Schedule.DataManager.SqlServer.Context;
using Schedule.DataManager.SqlServer.Entites;
using Schedule.DataManager.SqlServer.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var query = "EXEC Customer_Insert @CustomerCode,@CustomerName,@Mail,@Decription,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerCode", customer.CustomerCode, DbType.String);
            parameters.Add("CustomerName", customer.CustomerName, DbType.String);
            parameters.Add("Mail", customer.Mail, DbType.String);
            parameters.Add("Decription", customer.Decription, DbType.String);
            parameters.Add("UserID", customer.UserID, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdCustomer = new Customer
                {
                    CustomerName = customer.CustomerName,
                    CustomerCode = customer.CustomerCode,
                    Mail = customer.Mail,
                    Decription = customer.Decription,
                    UserID = customer.UserID
                };
                return createdCustomer;
            }
        }

        public async Task DeleteCustomer(int id)
        {
            var query = "EXEC Customer_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            var query = "SELECT * FROM Customer";
            using (var connection = _context.CreateConnection())
            {
                var Customers = await connection.QueryAsync<Customer>(query);
                return Customers.ToList();
            }
        }

        public Task<Customer> GetCustomerByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerByID(int id)
        {
            var query = "EXEC Customer_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var Customer = await connection.QueryFirstOrDefaultAsync<Customer>(query, new { Id = id });
                return Customer;
            }
        }
            
        public async Task UpdateCustomer(int id, Customer customer)
        {
            var query = "EXEC Customer_Update @Id,@CustomerCode,@CustomerName,@Mail,@Decription,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("CustomerCode", customer.CustomerCode, DbType.String);
            parameters.Add("CustomerName", customer.CustomerName, DbType.String);
            parameters.Add("Mail", customer.Mail, DbType.String);
            parameters.Add("Decription", customer.Decription, DbType.String);
            parameters.Add("UserID", customer.UserID, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
