using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.patient
{
    public class cn_detail
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string BP { get; set; }
        public string mmHg { get; set; }
        public string Pulse { get; set; }
        public string BPM { get; set; }
        public string Alcohol { get; set; }
        public string Cigar { get; set; }
        public string Service { get; set; }
        public DateTime DateReg { get; set; }
        public string time { get; set; }
        public string Customer { get; set; }
        public string HisSick { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy{ get; set; }

        public string bloodgr{ get; set; }
        public string hisphara{ get; set; }
        public string sodium{ get; set; }
        public string potassium{ get; set; }
        public string chloride{ get; set; }
        public string totalco2{ get; set; }
        public string uricacid{ get; set; }
        public string bun{ get; set; }
        public string creatinine{ get; set; }
        public string choiesterol{ get; set; }
        public string triglyceride{ get; set; }
        public string hdlc{ get; set; }
        public string ldlc{ get; set; }
        public string totalpro{ get; set; }
        public string albumin{ get; set; }
        public string globulin{ get; set; }
        public string totalbilirubin{ get; set; }
        public string direct{ get; set; }
        public string sgot{ get; set; }
        public string sgpt{ get; set; }
        public string alk{ get; set; }
        public string fbs{ get; set; }
        public string amphetamine{ get; set; }
        public string pregnancy{ get; set; }
        public string hbsag{ get; set; }
        public string hbsagb{ get; set; }
        public string antihavtotal{ get; set; }
        public string antihavlgm{ get; set; }
        public string vdrl{ get; set; }
        public string antihiv{ get; set; }
        public string tsh{ get; set; }
        public string freet3{ get; set; }
        public string freet4{ get; set; }
        public string t3{ get; set; }
        public string t4{ get; set; }
        public string hemoglobin{ get; set; }
        public string hematocrit{ get; set; }
        public string wbc{ get; set; }
        public string lym{ get; set; }
        public string gran{ get; set; }
        public string mid{ get; set; }
        public string platelet{ get; set; }
        public string eyecolor{ get; set; }
        public string xray{ get; set; }
        public string s1{ get; set; }
        public string s2xray{ get; set; }
        public string s2xray_comment { get; set; }
        public string s3cbc{ get; set; }
        public string s4cigar{ get; set; }
        public string s5chid{ get; set; }
        public string s6viral{ get; set; }
        public string s7cbc{ get; set; }
        public string s8{ get; set; }
        public string IDdate { get; set; }
        public int IDrunnumber { get; set; }
        public string color { get; set; }
        public string ph { get; set; }
        public string protien { get; set; }
        public string sg { get; set; }
        public string glucose { get; set; }
        public string ketone { get; set; }
        public string bilirubin { get; set; }
        public string urobilinogen { get; set; }
        public string blood { get; set; }
        public string leukocyte { get; set; }
        public string nitrite { get; set; }
        public string ascorbic { get; set; }
        public string urin1 { get; set; }
        public string urin2 { get; set; }
        public string stoolex { get; set; }
        public string stoolcul { get; set; }
        public string hissickbody { get; set; }
        public string hisfood { get; set; }
        public string hissickwork { get; set; }
        public string labinves { get; set; }
        public string medtype { get; set; }
        public string dif4 { get; set; }
        public string dif5 { get; set; }
        public string clarity { get; set; }
        public string mcv { get; set; }
        public string mch { get; set; }
        public string mchc { get; set; }
        public string type { get; set; }
        public string status { get; set; }


        //2023.11.07 최희문 필드 추가 
        public string Ekg { get; set; }

        //2023.11.19 최희문 필드 추가 
        public string Others_ekg { get; set; }
        public string Others_hearing { get; set; }
        public string Others_pulmonary { get; set; }

    }
}
