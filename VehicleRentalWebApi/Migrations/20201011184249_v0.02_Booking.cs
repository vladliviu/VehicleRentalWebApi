using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRentalWebApi.Migrations
{
    public partial class v002_Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookFrom = table.Column<DateTime>(nullable: false),
                    BookTo = table.Column<DateTime>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    TankBefore = table.Column<double>(nullable: false),
                    TankAfter = table.Column<double>(nullable: false),
                    Customer = table.Column<string>(nullable: true),
                    Damage = table.Column<string>(nullable: true),
                    VehicleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_VehicleID",
                table: "Booking",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
