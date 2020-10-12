using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRentalWebApi.Models;

namespace VehicleRentalWebApi.Data.EFCore
{
    public class EfCoreVehicleRepository : EfCoreRepository<Vehicle, VehicleRentalWebApiContext>
    {
        public EfCoreVehicleRepository(VehicleRentalWebApiContext context) : base(context)
        {

        }
    }
}
