using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.patient
{
    public class cn_checktype
    {
        public int ID { get; set; }
        public int TypeLabsID { get; set; }
        public int DetailID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateBy { get; set; }

    }
}
