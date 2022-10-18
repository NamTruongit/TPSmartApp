using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.Entities
{
    public class EmployeeTypeOfEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TOEmployeeId { get; set; }
    }
}
