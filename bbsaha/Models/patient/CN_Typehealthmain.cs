using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.patient
{
    public class cn_typehealthmain
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public string Remark { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
