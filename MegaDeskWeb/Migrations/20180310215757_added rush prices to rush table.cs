using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MegaDeskWeb.Migrations
{
    public partial class addedrushpricestorushtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "DeskQuote");

            migrationBuilder.AddColumn<int>(
                name: "priceLarge",
                table: "Rush",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceMedium",
                table: "Rush",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceSmall",
                table: "Rush",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priceLarge",
                table: "Rush");

            migrationBuilder.DropColumn(
                name: "priceMedium",
                table: "Rush");

            migrationBuilder.DropColumn(
                name: "priceSmall",
                table: "Rush");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "DeskQuote",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
