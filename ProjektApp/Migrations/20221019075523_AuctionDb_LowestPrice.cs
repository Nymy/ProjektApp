using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektApp.Migrations
{
    public partial class AuctionDb_LowestPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LowestPrice",
                table: "AuctionDbs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CloseDate", "LowestPrice" },
                values: new object[] { new DateTime(2022, 10, 17, 23, 59, 59, 0, DateTimeKind.Unspecified), 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowestPrice",
                table: "AuctionDbs");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CloseDate",
                value: new DateTime(2022, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
