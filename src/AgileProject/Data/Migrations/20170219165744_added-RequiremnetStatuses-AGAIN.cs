using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AgileProject.Data.Migrations
{
    public partial class addedRequiremnetStatusesAGAIN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.CreateTable(
                name: "RequirementStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Condition = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementStatuses", x => x.Id);
                });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Status",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropTable(
                name: "RequirementStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Statuses",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");
        }
    }
}
