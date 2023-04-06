using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Center.View
{
    public class cen_districtth
    {
        public string DistrictTH { get; set; }
        [Key]
        public string DistrictID { get; set; }
        public string ProvinceID { get; set; }
    }
}
