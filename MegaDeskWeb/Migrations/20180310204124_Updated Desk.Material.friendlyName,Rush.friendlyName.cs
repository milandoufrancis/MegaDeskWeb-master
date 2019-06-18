using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MegaDeskWeb.Migrations
{
    public partial class UpdatedDeskMaterialfriendlyNameRushfriendlyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "materialID",
                table: "Desk",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "materialID",
                table: "Desk");
        }
    }
}
