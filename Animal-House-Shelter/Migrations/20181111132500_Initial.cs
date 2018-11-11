using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalHouseShelter.Migrations.ApplicationDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Dogs",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Cats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Cats");
        }
    }
}
