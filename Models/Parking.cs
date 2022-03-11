using GLT.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Models
{
    public class Parking:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Parking Picture")]
        [Required(ErrorMessage = "Parking Picture is required")]
        public string Picture { get; set; }
        [Display(Name = "Parking Name")]
        [Required(ErrorMessage = "Parking name is required")]
        public string Name { get; set; }
        [Display(Name = "Parking Description")]
        [Required(ErrorMessage = "Parking description is required")]
        public string Description { get; set; }

        //Relationships 
        public List<Booking> Bookings { get; set; }
    }
}