using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.patient
{
    public class cn_patient
    {
        public int ID { get; set; }
        public string IDPatient { get; set; }
        public int IDrunnumber { get; set; }
        public string titlename { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public string birthday { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }
        public string IDCard { get; set; }
        public string IDpart { get; set; }

        public string address0 { get; set; }
        public string address { get; set; }
       
        public string address1 { get; set; }
        public string fname1 { get; set; }
        public string titlename1 { get; set; }
        public string skinCus { get; set; }

        //result
        public string ch6md { get; set; }
        public string tex6md { get; set; }
        public string ch6md0 { get; set; }
        public string ch6md1 { get; set; }
        public string ch6md2 { get; set; }
        public string ch6md3 { get; set; }
        public string ch6md4 { get; set; }
        public string ch6md5 { get; set; }
        public string ch6md6 { get; set; }
        public string ch6md7 { get; set; }
        public string ch6md8 { get; set; }
        public string tex6md8 { get; set; }

        //summary
        public string ch1md { get; set; }
        public string ch2md { get; set; }
        public string ch3md { get; set; }
        public string commentmd { get; set; }

        public string Tel { get; set; }
        public string Emname { get; set; }
        public string Emtel { get; set; }
        public string Relation { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Postcode { get; set; }
        public string career { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
    }
}
