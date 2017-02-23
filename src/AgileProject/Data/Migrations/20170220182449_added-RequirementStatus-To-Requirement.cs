using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileProject.Data.Migrations
{
    public partial class addedRequirementStatusToRequirement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Requirements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_StatusId",
                table: "Requirements",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_RequirementStatuses_StatusId",
                table: "Requirements",
                column: "StatusId",
                principalTable: "RequirementStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_RequirementStatuses_StatusId",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Requirements_StatusId",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Requirements");
        }
    }
}
