using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRentalWebApi.Migrations
{
    public partial class v003_SEED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Color", "Details", "LicensePlate", "Mileage", "Model", "Status" },
                values: new object[,]
                {
                    { 1, "Red", "A brand new sedan", "CJ-30-RUN", "3000", "Sedan", "Available" },
                    { 2, "Yellow", "A brand new coupe", "CJ-33-RUN", "40000", "Coupe", "Occupied" },
                    { 3, "Black", "A brand new SUV", "CJ-35-RUN", "55555", "SUV", "Broken" },
                    { 4, "Pink", "A brand new JEEP", "CJ-38-RUN", "14423", "JEEP", "Transfering" }
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookFrom", "BookTo", "Customer", "Damage", "Details", "TankAfter", "TankBefore", "VehicleID" },
                values: new object[] { 1, new DateTime(2020, 10, 12, 0, 24, 4, 339, DateTimeKind.Local).AddTicks(8990), new DateTime(2020, 10, 12, 1, 40, 4, 345, DateTimeKind.Local).AddTicks(4018), "Will Smith", "Minimum wear on the paint", "Short one hour and 16 minutes ride", 500.0, 750.0, 1 });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookFrom", "BookTo", "Customer", "Damage", "Details", "TankAfter", "TankBefore", "VehicleID" },
                values: new object[] { 2, new DateTime(2020, 10, 12, 0, 24, 4, 345, DateTimeKind.Local).AddTicks(7331), new DateTime(2020, 10, 12, 1, 31, 4, 345, DateTimeKind.Local).AddTicks(7354), "John Doe", "Hopefully no damage", "Short one hour and 7 minutes ride", 300.0, 333.0, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
