using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Models
{
    public class Car_Booking
    {
        public int BookingId { get; set; }

        public Booking Booking { get; set; }
        public int CarId { get; set; }

        public Car Car { get; set; }

    }
}