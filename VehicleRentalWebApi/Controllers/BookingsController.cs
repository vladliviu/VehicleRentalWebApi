using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRentalWebApi.Data.EFCore;
using VehicleRentalWebApi.Models;

namespace VehicleRentalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : VehicleRentalDBController<Booking, EfCoreBookingRepository>
    {
        public BookingsController(EfCoreBookingRepository repository) : base(repository)
        {

        }
    }
}
