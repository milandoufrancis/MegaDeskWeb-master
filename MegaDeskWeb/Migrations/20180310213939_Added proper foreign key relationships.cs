using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MegaDeskWeb.Migrations
{
    public partial class Addedproperforeignkeyrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "DeskQuote",
                newName: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Desk_materialID",
                table: "Desk",
                column: "materialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Desk_Material_materialID",
                table: "Desk",
                column: "materialID",
                principalTable: "Material",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desk_Material_materialID",
                table: "Desk");

            migrationBuilder.DropIndex(
                name: "IX_Desk_materialID",
                table: "Desk");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "DeskQuote",
                newName: "date");
        }
    }
}
