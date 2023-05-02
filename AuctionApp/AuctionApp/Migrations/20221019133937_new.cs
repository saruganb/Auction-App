using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "ExpiryDate",
                value: new DateTime(2022, 10, 19, 15, 39, 37, 96, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "AuctionId", "BidPrice", "Date", "UserName" },
                values: new object[] { -2, -1, 16500, new DateTime(2022, 10, 19, 15, 39, 37, 97, DateTimeKind.Local).AddTicks(130), "saruganb11@gmail.com" });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "AuctionId", "BidPrice", "Date", "UserName" },
                values: new object[] { -1, -1, 16000, new DateTime(2022, 10, 19, 15, 39, 37, 97, DateTimeKind.Local).AddTicks(120), "saruganb10@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "ExpiryDate",
                value: new DateTime(2022, 10, 19, 13, 59, 59, 389, DateTimeKind.Local).AddTicks(1150));
        }
    }
}
