using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    public partial class won : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ExpiryDate", "HighestBid" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 0, 53, 290, DateTimeKind.Local).AddTicks(9260), 16500 });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "Date",
                value: new DateTime(2022, 10, 20, 16, 0, 53, 290, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2022, 10, 20, 16, 0, 53, 290, DateTimeKind.Local).AddTicks(9490));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ExpiryDate", "HighestBid" },
                values: new object[] { new DateTime(2022, 10, 19, 15, 39, 37, 96, DateTimeKind.Local).AddTicks(9890), 15000 });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "Date",
                value: new DateTime(2022, 10, 19, 15, 39, 37, 97, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2022, 10, 19, 15, 39, 37, 97, DateTimeKind.Local).AddTicks(120));
        }
    }
}
