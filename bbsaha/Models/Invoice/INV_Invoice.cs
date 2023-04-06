using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Invoice
{
    public class inv_invoice
    { 
        public int ID { get; set; }
        public DateTime InvDate { get; set; }
        public string InvID { get; set; }
        public int CusID { get; set; }
        public string Cusname { get; set; }
        public string Address { get; set; }
        public string TaxID { get; set; }
        public decimal? Totalprice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Updatedate { get; set; }
        public string CreateBy { get; set; }
        public int BillNo { get; set; }
        public int Rewrite { get; set; }
        public string Status { get; set; }
        public DateTime? Datereceive { get; set; }
        public decimal? Receiveamount { get; set; }
        public string Appov { get; set; }
        public DateTime Datereceipt { get; set; }
        public DateTime? DateAppov { get; set; }

    }
}




