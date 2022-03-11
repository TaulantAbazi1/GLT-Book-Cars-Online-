using GLT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car_Booking>().HasKey(am => new
            {
                am.CarId,
                am.BookingId
            });
            modelBuilder.Entity<Car_Booking>().HasOne(m => m.Booking).WithMany(am => am.Cars_Bookings).HasForeignKey(m =>
             m.BookingId);
            modelBuilder.Entity<Car_Booking>().HasOne(m => m.Car).WithMany(am => am.Cars_Bookings).HasForeignKey(m =>
             m.CarId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Car_Booking> Cars_Bookings { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Producer> Producers { get; set; }

    }
}
