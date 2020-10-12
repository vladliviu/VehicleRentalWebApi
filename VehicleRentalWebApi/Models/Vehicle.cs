using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRentalWebApi.Models
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Details { get; set; }

        [Required]
        public string Status { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string Mileage { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
