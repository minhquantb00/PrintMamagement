using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    public partial class initialv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c43c413-fea9-42db-a3f7-758bdce6d0a1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("57bba7d4-b5ca-4ba4-bf9e-4b10428ca277"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6b02bac6-1f60-44d9-a748-4446bd977660"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ed6578a5-248e-4f48-9db7-c8fdcdbbabf6"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsActive", "RoleCode", "RoleName" },
                values: new object[,]
                {
                    { new Guid("52b7916e-e835-4c21-923f-1c258d189aeb"), true, "Admin", "Admin" },
                    { new Guid("5d596603-296d-4bd9-ae08-3c935268018b"), true, "Employee", "Employee" },
                    { new Guid("6aba15d0-e2a5-43ff-89ce-2e551c00c77f"), true, "Leader", "Leader" },
                    { new Guid("c6580fa6-bf8f-41f9-ab9b-74f9910b4275"), true, "Designer", "Designer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("52b7916e-e835-4c21-923f-1c258d189aeb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5d596603-296d-4bd9-ae08-3c935268018b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6aba15d0-e2a5-43ff-89ce-2e551c00c77f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c6580fa6-bf8f-41f9-ab9b-74f9910b4275"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsActive", "RoleCode", "RoleName" },
                values: new object[,]
                {
                    { new Guid("4c43c413-fea9-42db-a3f7-758bdce6d0a1"), true, "Admin", "Admin" },
                    { new Guid("57bba7d4-b5ca-4ba4-bf9e-4b10428ca277"), true, "Leader", "Leader" },
                    { new Guid("6b02bac6-1f60-44d9-a748-4446bd977660"), true, "Designer", "Designer" },
                    { new Guid("ed6578a5-248e-4f48-9db7-c8fdcdbbabf6"), true, "Employee", "Employee" }
                });
        }
    }
}
