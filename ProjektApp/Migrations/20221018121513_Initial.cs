using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BidsDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BiddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidAmount = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidsDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidsDbs_AuctionDbs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "CloseDate", "CreatedDate", "Description", "Title" },
                values: new object[] { -1, new DateTime(2022, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alot of orchids, very nice", "Auction for orchids" });

            migrationBuilder.InsertData(
                table: "BidsDbs",
                columns: new[] { "Id", "AuctionId", "BidAmount", "BiddedAt", "Name" },
                values: new object[] { -2, -1, 101, new DateTime(2022, 10, 17, 13, 21, 0, 0, DateTimeKind.Unspecified), "Nonno" });

            migrationBuilder.InsertData(
                table: "BidsDbs",
                columns: new[] { "Id", "AuctionId", "BidAmount", "BiddedAt", "Name" },
                values: new object[] { -1, -1, 100, new DateTime(2022, 10, 17, 13, 20, 0, 0, DateTimeKind.Unspecified), "Viktor" });

            migrationBuilder.CreateIndex(
                name: "IX_BidsDbs_AuctionId",
                table: "BidsDbs",
                column: "AuctionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidsDbs");

            migrationBuilder.DropTable(
                name: "AuctionDbs");
        }
    }
}
