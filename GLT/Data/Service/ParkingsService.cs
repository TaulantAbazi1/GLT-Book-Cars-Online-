using GLT.Data.Base;
using GLT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data.Service
{
    public class ParkingsService : EntityBaseRepository<Parking>, IParkingsService
    {
        public ParkingsService(AppDbContext context) : base(context)
        {
        }
    }
}
