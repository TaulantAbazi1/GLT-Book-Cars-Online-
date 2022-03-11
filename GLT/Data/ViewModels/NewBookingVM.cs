using GLT.Data;
using GLT.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Models
{
    public class NewBookingVM
    {
        [Display(Name = "Car name")]
        [Required(ErrorMessage = "Name is required")]
        
        public int Id { get; set; }

        [Display(Name = "Booking description")]
        [Required(ErrorMessage = "Description is required")]
        public string Name { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Booking poster URL")]
        [Required(ErrorMessage = "Price is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Booking start Date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Booking end Date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public BookingCategory BookingCategory { get; set; }

        //Relationships
        [Display(Name = "Select car(s)")]
        [Required(ErrorMessage = "Booking car(s) is required")]
        public List<int> CarIds { get; set; }

        [Display(Name = "Select a parking")]
        [Required(ErrorMessage = "Booking parking is required")]
        public int ParkingId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Booking producer is required")]
        public int ProducerId { get; set; }
    }
}