using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Models
{
    public class Parking
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Parking Picture")]
        public string Picture { get; set; }
        [Display(Name = "Parking Name")]
        public string Name { get; set; }
        [Display(Name = "Parking Description")]
        public string Description { get; set; }

        //Relationships 
        public List<Booking>  Bookings { get; set; }
        public string Logo { get; internal set; }
    }
}
