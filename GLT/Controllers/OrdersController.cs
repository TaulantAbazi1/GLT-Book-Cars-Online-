using GLT.Data.Cart;
using GLT.Data.Service;
using GLT.Data.Services;
using GLT.Data.Static;
using GLT.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GLT.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IBookingsService _bookingsService;
        private readonly BookCart _bookCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IBookingsService bookingsService, BookCart bookCart, IOrdersService ordersService)
        {
            _bookingsService = bookingsService;
            _bookCart = bookCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult BookCart()
        {
            var items = _bookCart.GetBookCartItems();
            _bookCart.BookCartItems = items;

            var response = new BookCartVM()
            {
                BookCart = _bookCart,
                BookCartTotal = _bookCart.GetBookCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToBookCart(int id)
        {
            var item = await _bookingsService.GetBookingByIdAsync(id);

            if (item != null)
            {
                _bookCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(BookCart));
        }

        public async Task<IActionResult> RemoveItemFromBookCart(int id)
        {
            var item = await _bookingsService.GetBookingByIdAsync(id);

            if (item != null)
            {
                _bookCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(BookCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _bookCart.GetBookCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _bookCart.ClearBookCartAsync();

            return View("OrderCompleted");
        }
    }
}