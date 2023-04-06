using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Company
{
    public class cus_agency
    {
        public int ID { get; set; }
        public string AgenCode { get; set; }
        public string AgenName { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
