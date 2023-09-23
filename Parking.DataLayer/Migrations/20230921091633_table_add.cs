using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingProject.DataLayer.Migrations
{
    public partial class table_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WageCoefficient",
                table: "Vehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StayDate",
                table: "CarParks",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WageCoefficient",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "StayDate",
                table: "CarParks");
        }
    }
}
