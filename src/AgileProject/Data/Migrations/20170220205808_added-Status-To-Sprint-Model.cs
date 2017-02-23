using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileProject.Data.Migrations
{
    public partial class addedStatusToSprintModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Sprints",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_StatusId",
                table: "Sprints",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Statuses_StatusId",
                table: "Sprints",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Statuses_StatusId",
                table: "Sprints");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_StatusId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Sprints");
        }
    }
}
