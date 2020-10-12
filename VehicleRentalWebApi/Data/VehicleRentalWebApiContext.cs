using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleRentalWebApi.Models;

namespace VehicleRentalWebApi.Data
{
    public class VehicleRentalWebApiContext : DbContext
    {
        public VehicleRentalWebApiContext (DbContextOptions<VehicleRentalWebApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    LicensePlate = "CJ-30-RUN",
                    Details = "A brand new sedan",
                    Status = "Available",
                    Model = "Sedan",
                    Color = "Red",
                    Mileage = "3000"
                },
                new Vehicle
                {
                    Id = 2,
                    LicensePlate = "CJ-33-RUN",
                    Details = "A brand new coupe",
                    Status = "Occupied",
                    Model = "Coupe",
                    Color = "Yellow",
                    Mileage = "40000"
                },
                 new Vehicle
                 {
                     Id = 3,
                     LicensePlate = "CJ-35-RUN",
                     Details = "A brand new SUV",
                     Status = "Broken",
                     Model = "SUV",
                     Color = "Black",
                     Mileage = "55555"
                 },
                  new Vehicle
                  {
                      Id = 4,
                      LicensePlate = "CJ-38-RUN",
                      Details = "A brand new JEEP",
                      Status = "Transfering",
                      Model = "JEEP",
                      Color = "Pink",
                      Mileage = "14423"
                  }



            );
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BookFrom = DateTime.Now,
                    BookTo = DateTime.Now.AddMinutes(76),
                    Details = "Short one hour and 16 minutes ride",
                    TankBefore = 750,
                    TankAfter  = 500,
                    Customer = "Will Smith",
                    Damage = "Minimum wear on the paint",
                    VehicleID = 1
                },

                new Booking
                {
                    Id = 2,
                    BookFrom = DateTime.Now,
                    BookTo = DateTime.Now.AddMinutes(67),
                    Details = "Short one hour and 7 minutes ride",
                    TankBefore = 333,
                    TankAfter = 300,
                    Customer = "John Doe",
                    Damage = "Hopefully no damage",
                    VehicleID = 3
                }
            );
        }


        public DbSet<VehicleRentalWebApi.Models.Vehicle> Vehicle { get; set; }

        public DbSet<VehicleRentalWebApi.Models.Booking> Booking { get; set; }
    }
}
