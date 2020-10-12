using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRentalWebApi.Models;

namespace VehicleRentalWebApi.Data.EFCore
{
    public class EfCoreBookingRepository : EfCoreRepository<Booking, VehicleRentalWebApiContext>
    {
        public EfCoreBookingRepository(VehicleRentalWebApiContext context) : base(context)
        {

        }
    }
}
