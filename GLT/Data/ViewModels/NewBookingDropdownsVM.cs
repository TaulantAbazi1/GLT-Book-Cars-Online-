using GLT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data.ViewModels
{
    public class NewBookingDropdownsVM
    {
        public NewBookingDropdownsVM()
        {
            Producers = new List<Producer>();
            Parkings = new List<Parking>();
            Cars = new List<Car>();
        }
        public List<Producer> Producers { get; set; }
        public List<Parking> Parkings { get; set; }
         public List<Car> Cars { get; set; }
    }
}
