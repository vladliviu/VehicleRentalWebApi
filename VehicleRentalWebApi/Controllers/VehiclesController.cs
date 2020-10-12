using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VehicleRentalWebApi.Data;
using VehicleRentalWebApi.Data.EFCore;
using VehicleRentalWebApi.Models;

namespace VehicleRentalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : VehicleRentalDBController<Vehicle, EfCoreVehicleRepository>
    {
        // The API calls will traverse the following layers: Controller -> Repository -> Entity Framework Core -> SQL Server
        public VehiclesController(EfCoreVehicleRepository repository) : base(repository)
        {

        }

        // Customs apis go here
    }
}
