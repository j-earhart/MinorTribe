using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MinorTribe.Migrations
{
    public partial class addedfavoritestobio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalBio",
                table: "Bios",
                newName: "SuperHero");

            migrationBuilder.AddColumn<string>(
                name: "Food",
                table: "Bios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Movie",
                table: "Bios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Food",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "Movie",
                table: "Bios");

            migrationBuilder.RenameColumn(
                name: "SuperHero",
                table: "Bios",
                newName: "PersonalBio");
        }
    }
}
