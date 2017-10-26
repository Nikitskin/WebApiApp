using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DBLayer.Migrations
{
    public partial class refactoredBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Users",
                nullable: true);
        }
    }
}
