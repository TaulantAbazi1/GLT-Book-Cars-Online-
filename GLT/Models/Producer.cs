using GLT.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "CarPictureURL")]
        [Required(ErrorMessage = "Car Picture is required")]
        public string CarPictureURL { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Brand must be between 3 and 50 chars")]
        public string Brand { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]

        public string Description { get; set; }

        //Relationships 
        public List<Booking> Bookings { get; set; }
    }
}

