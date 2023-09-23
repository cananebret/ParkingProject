using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingProject.DataLayer.Migrations
{
    public partial class fixed_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOut",
                table: "CarParks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOut",
                table: "CarParks");
        }
    }
}
