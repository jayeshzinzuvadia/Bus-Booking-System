using Microsoft.EntityFrameworkCore.Migrations;

namespace BusBookingSystem.Migrations
{
    public partial class NewColAddedInBusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalRateCounts",
                table: "Bus",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRateCounts",
                table: "Bus");
        }
    }
}
