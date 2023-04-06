using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Certificate
{
    public class cer_medical
    {
        public int ID { get; set; }
        public string cerid { get; set; }
        public DateTime CerDate { get; set; }
        public string IdcardCus { get; set; }
        public string FirstNameCus { get;set; }
        public string NametitleCus { get;set; }
        public string lastNameCus { get; set; }
        public string AddressCus { get; set; }
        public bool? Check_1 { get; set; }
        public string Detail_1 { get; set; }
        public bool? Check_2 { get; set; }
        public string Detail_2 { get; set; }
        public bool? Check_3 { get; set; }
        public string Detail_3 { get; set; }
        public bool? Check_4 { get; set; }
        public string Detail_4 { get; set; }
        public bool? Check_5 { get; set; }
        public string Detail_5 { get; set; }
        public string AddressCom { get; set; }
        public int? NameComId { get; set; }
        public Decimal? WeightCus { get; set; }
        public Decimal? HeightCus { get; set; }
        public string blood_pressureCus { get; set; }
        public int? PulseCus { get; set; }
        public bool? Body_healthStatusCus  { get; set; }
        public string Body_healthDetailCus  { get; set; }
        public string CommentCom { get; set; }
        public DateTime? CreateDate  { get; set; }
        public DateTime? UpdateDate  { get; set; }
        public string RecordBy  { get; set; }
        public string Status  { get; set; }
        public int? Runnumber { get; set; }
        public int DetailID { get; set; }
        public string type { get; set; }
         

    }
}
