using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Owner = table.Column<string>(type: "TEXT", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InitialPrice = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BidDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BidPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    AuctionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDbs_AuctionDbs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "Description", "ExpiryDate", "InitialPrice", "Name", "Owner" },
                values: new object[] { -1, "Good item", new DateTime(2022, 10, 18, 19, 7, 49, 253, DateTimeKind.Local).AddTicks(3210), 15000, "Mac", "Sarugan" });

            migrationBuilder.CreateIndex(
                name: "IX_BidDbs_AuctionId",
                table: "BidDbs",
                column: "AuctionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDbs");

            migrationBuilder.DropTable(
                name: "AuctionDbs");
        }
    }
}
