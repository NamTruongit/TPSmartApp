using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.Context
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
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
