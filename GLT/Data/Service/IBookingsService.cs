using GLT.Data.Base;
using GLT.Data.ViewModels;
using GLT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data.Service
{
    public interface IBookingsService:IEntityBaseRepository<Booking>
    {
        Task<Booking> GetBookingByIdAsync(int id);
        Task<NewBookingDropdownsVM> GetNewBookingDropdownsValues();
        Task AddNewBookingAsync(NewBookingVM data);
        Task UpdateBookingAsync(NewBookingVM data);

    }
}
