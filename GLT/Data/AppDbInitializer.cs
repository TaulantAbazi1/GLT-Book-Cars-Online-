using GLT.Data.Static;
using GLT.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLT.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Parking 
                if (!context.Parkings.Any())
                {
                    context.Parkings.AddRange(new List<Parking>()
                    {
                        new Parking()
                        {
                            Name = "Ulpiane",
                            Picture = "https://i.ytimg.com/vi/-NoztR_Sy6A/maxresdefault.jpg",
                            Description = "This is the description of the first parking"

                        },
                        new Parking()
                        {
                            Name = "Dardania",
                            Picture = "http://photos.wikimapia.org/p/00/01/88/14/25_big.jpg",
                            Description = "This is the description of the second parking"

                        },
                        new Parking()
                        {
                            Name = "Lakrishte",
                            Picture = "https://www.skyscrapercity.com/attachments/131424356_10218155017282725_1042460787429721412_o-jpg.868093/",
                            Description = "This is the description of the third parking"

                        },
                         new Parking()
                        {
                            Name = "lala",
                            Picture = "https://www.skyscrapercity.com/attachments/131424356_10218155017282725_1042460787429721412_o-jpg.868093/",
                            Description = "This is the description of the third parking"

                        }

                    });
                    context.SaveChanges();

                }

                //Cars
                if (!context.Cars.Any())
                {
                    {
                        context.Cars.AddRange(new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Merce",
                            CarPictureURL = "https://i.ytimg.com/vi/-NoztR_Sy6A/maxresdefault.jpg",
                            Description = "This is the description of the first parking"

                        },
                        new Car()
                        {
                            
                            Brand = "Audi",
                            CarPictureURL = "http://photos.wikimapia.org/p/00/01/88/14/25_big.jpg",
                            Description = "This is the description of the second parking"

                        },
                        new Car()
                        {
                            Brand = "BMW",
                            CarPictureURL = "https://www.skyscrapercity.com/attachments/131424356_10218155017282725_1042460787429721412_o-jpg.868093/",
                            Description = "This is the description of the third parking"

                        },
                         new Car()
                        {
                            Brand = "Golf",
                            CarPictureURL = "https://www.skyscrapercity.com/attachments/131424356_10218155017282725_1042460787429721412_o-jpg.868093/",
                            Description = "This is the description of the third parking"

                        }

                    });
                        context.SaveChanges();
                    }
                    //Producers
                    if (!context.Producers.Any())
                    {
                        {
                            context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Name = "Linor",
                            Brand = "Merce",
                            Description = "ghagha",
                            CarPictureURL = "https://www.skyscrapercity.com/attachments/131424356_10218155017282725_1042460787429721412_o-jpg.868093/",
                        },

                        new Producer()
                        {
                            Name = "Linor",
                            Brand = "Audi",
                            Description = "hiii",
                            CarPictureURL = "https://www.skyscrapercity.com/attachments/131424356_10218155017282725_1042460787429721412_o-jpg.868093/",
                        },
                        new Producer()
                        {
                            Name = "Linor",
                            Brand = "BMW",
                            Description = "hello",
                            CarPictureURL = "https://www.skyscrapercity.com/attachments/131424356_10218155017282725_1042460787429721412_o-jpg.868093/",
                        },


                    });
                            context.SaveChanges();
                        }
                        //Booking
                        if (!context.Bookings.Any())
                        {
                            {
                                context.Bookings.AddRange(new List<Booking>()
                    {
                        new Booking()
                        {
                            Name = "Audi",
                            Description = "This is the description of the first parking",
                            Price = 40.55,
                            ImageURL = "https://i.ytimg.com/vi/-NoztR_Sy6A/maxresdefault.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(-2),
                            ParkingId = 4,
                            ProducerId = 4,
                            BookingCategory = BookingCategory.Yearly,

                        },
                       new Booking()
                        {
                            Name = "Audi",
                            Description = "This is the description of the first parking",
                            Price = 40.55,
                            ImageURL = "https://i.ytimg.com/vi/-NoztR_Sy6A/maxresdefault.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(-2),
                            ParkingId = 4,
                            ProducerId = 4,
                            BookingCategory = BookingCategory.Monthly,

                        },
                        new Booking()
                        {
                            Name = "Audi",
                            Description = "This is the description of the first parking",
                            Price = 40.55,
                            ImageURL = "https://i.ytimg.com/vi/-NoztR_Sy6A/maxresdefault.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(-2),
                            ParkingId = 4,
                            ProducerId = 4,
                            BookingCategory = BookingCategory.Daily,

                        },


                    }) ;
                                context.SaveChanges();
                            }
                            //Cars & Bookings
                            if (!context.Cars_Bookings.Any())
                            {
                                context.Cars_Bookings.AddRange(new List<Car_Booking>()
                    {
                        new Car_Booking()
                        {
                             CarId = 5,
                            BookingId = 5,

                        },
                        new Car_Booking()
                        {
                             CarId = 3,
                            BookingId = 6,

                        },
                        new Car_Booking()
                        {
                             CarId = 4,
                            BookingId = 6,

                        },
                         new Car_Booking()
                        {
                            CarId = 5,
                            BookingId = 6,

                        }

                    });
                                context.SaveChanges();
                            }

                        }
                    }
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@glt.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@glt.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}