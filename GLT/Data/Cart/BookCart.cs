using GLT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data.Cart
{
    public class BookCart
    {
        public AppDbContext _context { get; set; }

        public string BookCartId { get; set; }
        public List<BookCartItem> BookCartItems { get; set; }

        public BookCart(AppDbContext context)
        {
            _context = context;
        }

        public static BookCart GetBookCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new BookCart(context) { BookCartId = cartId };
        }

        public void AddItemToCart(Booking Booking)
        {
            var BookCartItem = _context.BookCartItems.FirstOrDefault(n => n.Booking.Id == Booking.Id && n.BookCartId == BookCartId);

            if (BookCartItem == null)
            {
                BookCartItem = new BookCartItem()
                {
                    BookCartId = BookCartId,
                    Booking = Booking,
                    Amount = 1
                };

                _context.BookCartItems.Add(BookCartItem);
            }
            else
            {
                BookCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Booking Booking)
        {
            var BookCartItem = _context.BookCartItems.FirstOrDefault(n => n.Booking.Id == Booking.Id && n.BookCartId == BookCartId);

            if (BookCartItem != null)
            {
                if (BookCartItem.Amount > 1)
                {
                    BookCartItem.Amount--;
                }
                else
                {
                    _context.BookCartItems.Remove(BookCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<BookCartItem> GetBookCartItems()
        {
            return BookCartItems ?? (BookCartItems = _context.BookCartItems.Where(n => n.BookCartId == BookCartId).Include(n => n.Booking).ToList());
        }

        public double GetBookCartTotal() => _context.BookCartItems.Where(n => n.BookCartId == BookCartId).Select(n => n.Booking.Price * n.Amount).Sum();

        public async Task ClearBookCartAsync()
        {
            var items = await _context.BookCartItems.Where(n => n.BookCartId == BookCartId).ToListAsync();
            _context.BookCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}