using GLT.Data.Base;
using GLT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data.Service
{
    public class CarsService : EntityBaseRepository<Car>, ICarsService
    {
        public CarsService(AppDbContext context) : base(context)
        {

        }
    }
}
        
       
