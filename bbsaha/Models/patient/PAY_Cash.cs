using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.patient
{
    public class pay_cash
    {
        public int ID { get; set; }
        public int DetailID { get; set; }
        public DateTime Dateclear { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string type { get; set; }

    }
}
