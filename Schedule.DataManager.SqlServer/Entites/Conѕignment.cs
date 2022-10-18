using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.Entites
{
    public class Conѕignment
    {
        public int Id { get; set; }
        public string ConѕignmentCode { get; set; }
        public string Decription { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserID { get; set; }
    }

}
