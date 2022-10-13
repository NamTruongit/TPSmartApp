using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace TPApi.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configurarion;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configurarion)  
        {
            _configurarion = configurarion;
            _connectionString = _configurarion.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection()=> new SqlConnection(_connectionString);
    }
}
