using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileProject.Data.Migrations
{
    public partial class addeddescriptionfieldtoallmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sprints",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Requirements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");
        }
    }
}
