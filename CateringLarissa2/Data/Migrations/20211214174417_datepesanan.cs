using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CateringLarissa2.Data.Migrations
{
    public partial class datepesanan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "orderedat",
                table: "Pesan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "arrivedat",
                table: "Pesan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.DropColumn(
              name: "orderedat",
              table: "Pesan");

            migrationBuilder.DropColumn(
              name: "arrivedat",
              table: "Pesan");
        }
    }
}
