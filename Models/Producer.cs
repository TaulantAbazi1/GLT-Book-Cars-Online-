using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "CarPictureURL")]
        public string CarPictureURL { get; set; }
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        [Display(Name = "Description")]

        public string Description { get; set; }

        //Relationships 
        public List<Booking> Bookings { get; set; }
    }
}
