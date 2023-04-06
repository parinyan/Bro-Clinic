using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Certificate
{
    public class cer_header
    {

        public int ID { get; set; }
        public string titleCom { get; set; }
        public string FnameCom { get; set; }
        public string LnameCom { get; set; }
        public string LicenseIdCom { get; set; }
        public string LicenseAdrCom { get; set; }
        public string NameClinic {get;set;}
        public string AdrClinic { get; set; }
        public string TelClinic { get; set; }
        public string EmailClinic { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string Status { get; set; }



    }
}
