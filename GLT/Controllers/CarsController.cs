using GLT.Data;
using GLT.Data.Service;
using GLT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _service;

        public CarsController(ICarsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data =  await _service.GetAllAsync();
            return View(data);
        }
       public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int id, [Bind("Id,Brand,CarPictureURL,Description")] Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            await _service.AddAsync(car);
            return RedirectToAction(nameof(Index));
        }

        //Get:Cars/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("Notfound");
            return View(carDetails);
        
        }
        //Get : Cars/Edit/
        public async Task<IActionResult> Edit(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("NotFound");
            return View(carDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,CarPictureURL,Description")] Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            await _service.UpdateAsync (id,car);
            return RedirectToAction(nameof(Index));
        }

        //Get:Cars / Delete
        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("NotFound");
            return View(carDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
           
            return RedirectToAction(nameof(Index));
        }
    }
}