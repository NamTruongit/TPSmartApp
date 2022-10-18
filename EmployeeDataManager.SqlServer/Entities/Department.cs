using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DeparmentName { get; set; }
        public string Decription { get; set; }
        public string DepartmentCode { get; set; }
    }
}
