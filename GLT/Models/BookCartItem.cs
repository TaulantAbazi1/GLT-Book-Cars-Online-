using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Models
{
    public class BookCartItem
    {
        [Key]
        public int Id { get; set; }

        public Booking Booking { get; set; }
        public int Amount { get; set; }


        public string BookCartId { get; set; }
    }
}