using GLT.Data.Base;
using GLT.Data.ViewModels;
using GLT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data.Service
{
    public class BookingsService : EntityBaseRepository<Booking>, IBookingsService
    {

        private readonly AppDbContext _context;

        public BookingsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBookingAsync(NewBookingVM data)
        {
            var newBooking = new Booking()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ParkingId = data.ParkingId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                BookingCategory = data.BookingCategory,
                ProducerId = data.ProducerId
            };
            await _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();

            //ADD Booking Cars
            foreach (var carId in data.CarIds)
            {
                var newCarBooking = new Car_Booking()
                {
                    BookingId = newBooking.Id,
                    CarId = carId
                };
                await _context.Cars_Bookings.AddAsync(newCarBooking);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<Booking> GetBookingByIdAsync(int id)
        {

            var bookingDetails = await _context.Bookings
                .Include(c => c.Parking)
                .Include(p => p.Producer)
                .Include(am => am.Cars_Bookings).ThenInclude(a => a.Car)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookingDetails;
        }

   
        public async Task<NewBookingDropdownsVM> GetNewBookingDropdownsValues()
        {
            var response = new NewBookingDropdownsVM()
            {
                Cars = await _context.Cars.OrderBy(n => n.Brand).ToListAsync(),
                Parkings = await _context.Parkings.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.Name).ToListAsync(),
            };
             return response;

        }

        public async Task UpdateBookingAsync(NewBookingVM data)
        {
            var dbBooking = await _context.Bookings.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbBooking != null)
            {
                dbBooking.Name = data.Name;
                dbBooking.Description = data.Description;
                dbBooking.Price = data.Price;
                dbBooking.ImageURL = data.ImageURL;
                dbBooking.ParkingId = data.ParkingId;
                dbBooking.StartDate = data.StartDate;
                dbBooking.EndDate = data.EndDate;
                dbBooking.BookingCategory = data.BookingCategory;
                dbBooking.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remoce existing cars

            var existingCarsDb = _context.Cars_Bookings.Where(n => n.BookingId == data.Id).ToList();
            _context.Cars_Bookings.RemoveRange(existingCarsDb);
            await _context.SaveChangesAsync();
            //ADD Booking Cars
            foreach (var carId in data.CarIds)
            {
                var newCarBooking = new Car_Booking()
                {
                    BookingId = data.Id,
                    CarId = carId
                };
                await _context.Cars_Bookings.AddAsync(newCarBooking);
            }
            await _context.SaveChangesAsync();
        }
    }
}
       