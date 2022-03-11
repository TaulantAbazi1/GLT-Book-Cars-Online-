using GLT.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data.ViewComponents
{
    public class BookCartSummary:ViewComponent
    {
        private readonly BookCart _BookCart;
        public BookCartSummary(BookCart BookCart)
        {
            _BookCart = BookCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _BookCart.GetBookCartItems();

            return View(items.Count);
        }
    }
}