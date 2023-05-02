using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    public partial class Highestbid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HighestBid",
                table: "AuctionDbs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ExpiryDate", "HighestBid" },
                values: new object[] { new DateTime(2022, 10, 19, 13, 59, 59, 389, DateTimeKind.Local).AddTicks(1150), 15000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestBid",
                table: "AuctionDbs");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "ExpiryDate",
                value: new DateTime(2022, 10, 18, 19, 39, 9, 334, DateTimeKind.Local).AddTicks(6880));
        }
    }
}
