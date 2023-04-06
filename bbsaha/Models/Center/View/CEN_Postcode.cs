using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bbsaha.Models.Center.View
{
    public class cen_postcode
    {
        [Key]
        public string PostCode { get; set; }
        
        public string DistrictID { get; set; }
       
    }
}
