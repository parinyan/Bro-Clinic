using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Account
{
    public class acc_users
    {
        [Key]
        public string Account { get; set; }
        public string Password { get; set; }
        public string NickNameEN { get; set; }
        public string NickNameTH { get; set; }
        public bool SupUser { get; set; }
        public string Refno { get; set; }
        public bool? Staff { get; set; } 
        public bool? Manager { get; set; }
        public bool ManPower { get; set; }
        public bool TimeAttendance { get; set; }
        public bool Administration { get; set; }
        public DateTime RecordDate { get; set; }
        public string RecordBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Guid RowPointer { get; set; }
        

    }

    public class ListUser
    {
        public List<acc_users> acc { get; set; }
    }

}
