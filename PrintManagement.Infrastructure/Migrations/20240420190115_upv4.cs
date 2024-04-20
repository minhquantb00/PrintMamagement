using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    public partial class upv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyPerformanceIndicators_Users_UserId",
                table: "KeyPerformanceIndicators");

            migrationBuilder.DropIndex(
                name: "IX_KeyPerformanceIndicators_UserId",
                table: "KeyPerformanceIndicators");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "KeyPerformanceIndicators");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicators_EmployeeId",
                table: "KeyPerformanceIndicators",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyPerformanceIndicators_Users_EmployeeId",
                table: "KeyPerformanceIndicators",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyPerformanceIndicators_Users_EmployeeId",
                table: "KeyPerformanceIndicators");

            migrationBuilder.DropIndex(
                name: "IX_KeyPerformanceIndicators_EmployeeId",
                table: "KeyPerformanceIndicators");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "KeyPerformanceIndicators",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicators_UserId",
                table: "KeyPerformanceIndicators",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyPerformanceIndicators_Users_UserId",
                table: "KeyPerformanceIndicators",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
