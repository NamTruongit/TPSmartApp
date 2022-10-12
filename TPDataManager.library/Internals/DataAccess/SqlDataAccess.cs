using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDataManager.library.Internals.DataAccess
{
    public class SqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GetConnection(string name)
        {
            return _configuration.GetConnectionString(name);
        }
    }
}
