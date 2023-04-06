using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Invoice
{
    public class inv_detaillist
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string CusName { get; set; }
        public int InvID { get; set; }
        public string FirstnameTH { get; set; }
        public string LastNameTH { get; set; }
        public string FirstNameEN { get; set; }
        public string LastNameEN { get; set; }
        public string Service { get; set; }
        public decimal Amount { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime updatedate { get; set; }
        public string CreateBy { get; set; }
        public string Status { get; set; }

    }
}
