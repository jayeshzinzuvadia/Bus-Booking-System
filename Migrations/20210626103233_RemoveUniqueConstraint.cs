using Microsoft.EntityFrameworkCore.Migrations;

namespace BusBookingSystem.Migrations
{
    public partial class RemoveUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seat_BusRouteId",
                table: "Seat");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_BusRouteId",
                table: "Seat",
                column: "BusRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seat_BusRouteId",
                table: "Seat");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_BusRouteId",
                table: "Seat",
                column: "BusRouteId",
                unique: true);
        }
    }
}
