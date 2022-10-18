using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public string Decription { get; set; }
        public string PositionCode { get; set; }
    }
}
