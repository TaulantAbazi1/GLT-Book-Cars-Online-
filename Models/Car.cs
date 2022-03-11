using GLT.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Models
{
    public class Car:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Car Picture ")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string CarPictureURL { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Full Brand is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string Brand { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]

        public string Description { get; set; }

        public List<Car_Booking> Cars_Bookings { get; set; }
        public string Name { get; internal set; }
        public string Logo { get; internal set; }
    }
}