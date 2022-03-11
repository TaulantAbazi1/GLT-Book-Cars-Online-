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
    public class Booking:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }


        public double Price { get; set; }


        public string ImageURL { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }

        public BookingCategory BookingCategory { get; set; }

        //Relationships
        public List<Car_Booking> Cars_Bookings { get; set; }

        //Parking

        public int ParkingId { get; set; }
        [ForeignKey("ParkingId")]
        public Parking Parking { get; set; }

        //Producer

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}