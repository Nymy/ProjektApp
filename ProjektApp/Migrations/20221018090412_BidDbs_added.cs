using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektApp.Migrations
{
    public partial class BidDbs_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BiddedAt",
                table: "BidsDbs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "BidsDbs",
                columns: new[] { "Id", "AuctionId", "BidAmount", "BiddedAt", "Name" },
                values: new object[] { -2, -1, 101, new DateTime(2022, 10, 17, 13, 21, 0, 0, DateTimeKind.Unspecified), "Nonno" });

            migrationBuilder.InsertData(
                table: "BidsDbs",
                columns: new[] { "Id", "AuctionId", "BidAmount", "BiddedAt", "Name" },
                values: new object[] { -1, -1, 100, new DateTime(2022, 10, 17, 13, 20, 0, 0, DateTimeKind.Unspecified), "Viktor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidsDbs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "BidsDbs",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "BiddedAt",
                table: "BidsDbs");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 9, 50, 46, 223, DateTimeKind.Local).AddTicks(7816));
        }
    }
}
