using GLT.Data;
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
        private readonly AppDbContext _context;

        public ParkingsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var allParkings = await _context.Parkings.ToListAsync();
            return View(allParkings);
        }
    }
}
