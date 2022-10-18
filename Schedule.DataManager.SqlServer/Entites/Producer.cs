using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.Entites
{
    public class Producer
    {
        public int Id { get; set; }
        public string ProducerCode { get; set; }
        public string Decription { get; set; }
        public string Mail { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserID { get; set; }
    }
}
