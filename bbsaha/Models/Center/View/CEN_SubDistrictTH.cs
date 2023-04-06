using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Center.View
{
    public class cen_subdistrictth
    {
        public string SubDistrictTH { get; set; }
        [Key]
        public string SubDistrictID { get; set; }
        public string DistrictID { get; set; }
    }
}
