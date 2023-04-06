using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Company
{
    public class cus_company
    {
        [Key]
        public int ID { get; set; }
        public string NameSimple { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyNameTH { get; set; }
        public string CompanyNameEN { get; set; }
        public int? DateWorking { get; set; }
        public DateTime? Create_date { get; set; }
        public string Create_by { get; set; }
        public string Status { get; set; }
        public int ComIDTigersoft { get; set; }
        public string Type { get; set; }
    }
}
