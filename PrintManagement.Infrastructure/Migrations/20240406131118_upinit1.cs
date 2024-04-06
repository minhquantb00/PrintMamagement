using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    public partial class upinit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsActive", "RoleCode", "RoleName" },
                values: new object[,]
                {
                    { new Guid("09f57a24-01d8-4e4f-9fa6-d15518f4bffc"), true, "Employee", "Employee" },
                    { new Guid("33309333-5dfd-4858-843a-c0fd1d19dadb"), true, "Leader", "Leader" },
                    { new Guid("3b29e3ee-4173-47b2-8f8f-eb8637cdad7c"), true, "Admin", "Admin" },
                    { new Guid("ece759df-37ce-47c0-bdef-da201a4c9bc4"), true, "Designer", "Designer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("09f57a24-01d8-4e4f-9fa6-d15518f4bffc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("33309333-5dfd-4858-843a-c0fd1d19dadb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3b29e3ee-4173-47b2-8f8f-eb8637cdad7c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ece759df-37ce-47c0-bdef-da201a4c9bc4"));
        }
    }
}
