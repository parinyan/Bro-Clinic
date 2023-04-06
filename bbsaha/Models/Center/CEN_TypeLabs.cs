using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Center
{
    public class cen_typelabs
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string TypeName { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
