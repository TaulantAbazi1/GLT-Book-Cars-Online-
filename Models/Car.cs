using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Car Picture ")]
        public string CarPictureURL { get; set; }
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        [Display(Name = "Description")]

        public string Description { get; set; }

        public List<Car_Booking> Cars_Bookings { get; set; }
        public string Name { get; internal set; }
        public string Logo { get; internal set; }
    }
}
