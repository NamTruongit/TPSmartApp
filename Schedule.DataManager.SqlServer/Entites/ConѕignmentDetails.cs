using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.Entites
{
    public class ConѕignmentDetails
    {
        public int Id { get; set; }
        public int CommodityId { get; set; }
        public int CustomerId { get; set; }
        public int ConѕignmentId { get; set; }
        public string JPCode { get; set; }
        public string VNCode { get; set; }
        public string Note { get; set; }
        public DateTime ExportDateFromHCM { get; set; }
        public DateTime ExportDateFromHue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserID { get; set; }
    }
}
