using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.Entites
{
    public class Commodity
    {
        public int Id { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public string Decription { get; set; }
        public string CommodityGroup { get; set; }
        public int ProducerID { get; set; }
        public string Abbreviation { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserID { get; set; }

    }
}
