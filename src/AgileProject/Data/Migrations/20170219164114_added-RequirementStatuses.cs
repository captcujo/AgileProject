using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileProject.Data.Migrations
{
    public partial class addedRequirementStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Statuses",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Status",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");
        }
    }
}
