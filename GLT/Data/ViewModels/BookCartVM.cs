using GLT.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data.ViewModels
{
    public class BookCartVM
    {
        public BookCart BookCart { get; set; }
        public double BookCartTotal { get; set; }
    }
}
