using Microsoft.EntityFrameworkCore.Migrations;

namespace BusBookingSystem.Migrations
{
    public partial class AddedBusVehicleNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusVehicleNumber",
                table: "Ticket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusVehicleNumber",
                table: "Ticket");
        }
    }
}
