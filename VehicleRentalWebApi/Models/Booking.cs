using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRentalWebApi.Models
{
    public class Booking : IEntity
    {
        public int Id { get; set; }

        [Required]
        public DateTime BookFrom { get; set; }
        [Required]
        public DateTime BookTo { get; set; }

        public string Details { get; set; }

        [Required]
        public double TankBefore { get; set; }
        public double TankAfter { get; set; }

        public string Customer { get; set; }
        public string Damage { get; set; }

        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
