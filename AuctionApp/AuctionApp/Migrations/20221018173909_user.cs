using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ExpiryDate", "Owner" },
                values: new object[] { new DateTime(2022, 10, 18, 19, 39, 9, 334, DateTimeKind.Local).AddTicks(6880), "sarugan@kth.se" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ExpiryDate", "Owner" },
                values: new object[] { new DateTime(2022, 10, 18, 19, 7, 49, 253, DateTimeKind.Local).AddTicks(3210), "Sarugan" });
        }
    }
}
