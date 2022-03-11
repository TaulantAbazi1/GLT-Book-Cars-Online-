using GLT.Data;
using GLT.Data.Service;
using GLT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Controllers
{
    public class ParkingsController : Controller
    {
        private readonly IParkingsService _service;

        public ParkingsController(IParkingsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int id, [Bind("Id,Picture,Name,Description,Bookings,Logo")] Parking parking)
        {
            if (!ModelState.IsValid)
            {
                return View(parking);
            }
            await _service.AddAsync(parking);
            return RedirectToAction(nameof(Index));
        }

        //Get:Cars/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var parkingDetails = await _service.GetByIdAsync(id);
            if (parkingDetails == null) return View("Notfound");
            return View(parkingDetails);

        }
        //Get : Cars/Edit/
        public async Task<IActionResult> Edit(int id)
        {
            var parkingDetails = await _service.GetByIdAsync(id);
            if (parkingDetails == null) return View("NotFound");
            return View(parkingDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Picture,Name,Description,Bookings,Logo")] Parking parking)
        {
            if (!ModelState.IsValid)
            {
                return View(parking);
            }
            await _service.UpdateAsync(id, parking);
            return RedirectToAction(nameof(Index));
        }

        //Get:Cars / Delete
        public async Task<IActionResult> Delete(int id)
        {
            var parkingDetails = await _service.GetByIdAsync(id);
            if (parkingDetails == null) return View("NotFound");
            return View(parkingDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingDetails = await _service.GetByIdAsync(id);
            if (parkingDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}