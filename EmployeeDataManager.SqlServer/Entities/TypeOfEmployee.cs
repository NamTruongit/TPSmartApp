using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.SqlServer.Entities
{
    public class TypeOfEmployee
    {
        public int Id { get; set; }
        public string TypeOfEmployeeName { get; set; }
        public string Decription { get; set; }
    }
}
