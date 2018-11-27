using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheckPoint4.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        public int InstrumentID { get; set; }

        [Required(ErrorMessage ="Please Enter an Instrument Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter \"New\" or \"Used\"")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please Enter a Price")]
        public double Price { get; set; }

        [ForeignKey("Client")]
        public virtual int ClientID { get; set; }
        public virtual Client Client { get; set; }
        
    }
}