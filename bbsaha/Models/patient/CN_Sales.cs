using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.patient
{
    public class cn_sales
    {
        public int ID { get; set; }
        public int TypeName { get; set; }
        public int DetailID { get; set; }
        public decimal Price { get; set; }
        public int PerReceiver { get; set; }
        public DateTime? ReceivePayDate { get; set; }
        public string Recommend { get; set; }
        public string Remark { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public int MedType { get; set; }
        public string Company { get; set; }
        public DateTime? ReceiveDeDate { get; set; }
        public decimal ReceivePrice { get; set; }
        public string IDreciept { get; set; }
        public int IDrunnumber { get; set; }
        public decimal Pricerec { get; set; }
    }
}
