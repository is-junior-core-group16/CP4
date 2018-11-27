using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckPoint4.Models
{
    public class Verification
    {
        [Key]
        public int VID { get; set; }
        public string UName { get; set; }
        public string PWord { get; set; }
    }
}

