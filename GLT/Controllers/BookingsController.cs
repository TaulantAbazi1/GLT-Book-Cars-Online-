using GLT.Data;
using GLT.Data.Service;
using GLT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingsService _service;

        public BookingsController(IBookingsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            var allBookings = await _service.GetAllAsync(n => n.Parking);
            return View(allBookings);
        }

        public async Task<IActionResult> Filter(string searchString)
        {

            var allBookings = await _service.GetAllAsync(n => n.Parking);

            if (!string.IsNullOrEmpty(searchString))
            {  
                var filteredResult = allBookings.Where(n => n.Name.Contains(searchString) || n.Description.Contains
                (searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allBookings);

        }

        //Get: Bookings/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var bookingDetail = await _service.GetBookingByIdAsync(id);
            return View(bookingDetail);
        }

        //Get: Bookings/Create

        public async Task<IActionResult> Create()
        {
            var bookingDropdownsData = await _service.GetNewBookingDropdownsValues();

            ViewBag.Parkings = new SelectList(bookingDropdownsData.Parkings, "Id", "Name");
            ViewBag.Producers = new SelectList(bookingDropdownsData.Producers, "Id", "Name");
            ViewBag.Cars = new SelectList(bookingDropdownsData.Cars, "Id", "Brand");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBookingVM booking)
        {
            if (!ModelState.IsValid)
            {
                var bookingDropdownsData = await _service.GetNewBookingDropdownsValues();


                ViewBag.Parkings = new SelectList(bookingDropdownsData.Parkings, "Id", "Name");
                ViewBag.Producers = new SelectList(bookingDropdownsData.Producers, "Id", "Name");
                ViewBag.Cars = new SelectList(bookingDropdownsData.Cars, "Id", "Brand");


                return View(booking);
            }

            await _service.AddNewBookingAsync(booking);
            return RedirectToAction(nameof(Index));
        }

        //GET Bookings/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var bookingDetails = await _service.GetBookingByIdAsync(id);
            if (bookingDetails == null) return View("NotFound");

            var response = new NewBookingVM()
            {
                Id = bookingDetails.Id,
                Name = bookingDetails.Name,
                Description = bookingDetails.Description,
                Price = bookingDetails.Price,
                StartDate = bookingDetails.StartDate,
                EndDate = bookingDetails.EndDate,
                ImageURL = bookingDetails.ImageURL,
                BookingCategory = bookingDetails.BookingCategory,
                ParkingId = bookingDetails.ParkingId,
                ProducerId = bookingDetails.ProducerId,
                CarIds = bookingDetails.Cars_Bookings.Select(n => n.CarId).ToList(),
            };

            var bookingDropdownsData = await _service.GetNewBookingDropdownsValues();
            ViewBag.Parkings = new SelectList(bookingDropdownsData.Parkings, "Id", "Name");
            ViewBag.Producers = new SelectList(bookingDropdownsData.Producers, "Id", "Name");
            ViewBag.Cars = new SelectList(bookingDropdownsData.Cars, "Id", "Brand");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookingVM booking)
        {
            if (id != booking.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bookingDropdownsData = await _service.GetNewBookingDropdownsValues();

                ViewBag.Parkings = new SelectList(bookingDropdownsData.Parkings, "Id", "Name");
                ViewBag.Producers = new SelectList(bookingDropdownsData.Producers, "Id", "FullName");
                ViewBag.Cars = new SelectList(bookingDropdownsData.Cars, "Id", "FullName");

                return View(booking);
            }

            await _service.UpdateBookingAsync(booking);
            return RedirectToAction(nameof(Index));
        }

    }
}