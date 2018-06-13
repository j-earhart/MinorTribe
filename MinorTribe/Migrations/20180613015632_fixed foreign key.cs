using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MinorTribe.Migrations
{
    public partial class fixedforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_States_State",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_State",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_StateId",
                table: "Contacts",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_States_StateId",
                table: "Contacts",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_States_StateId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_StateId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_State",
                table: "Contacts",
                column: "State");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_States_State",
                table: "Contacts",
                column: "State",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
