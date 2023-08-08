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
