using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    public partial class initialv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1e6fd561-9508-4ed7-86ba-f9bde4c27d68"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4938687b-e20e-4199-b2d0-8475ff2ee295"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4cec3911-8d7f-469d-a9b7-3efb49b88071"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f40fcc24-d353-47b2-bf57-31611d8605ed"));

            migrationBuilder.AddColumn<string>(
                name: "RequestDescriptionFromCustomer",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsActive", "RoleCode", "RoleName" },
                values: new object[,]
                {
                    { new Guid("10573a6c-e034-4da6-bec8-b51f12262f7c"), true, "Employee", "Employee" },
                    { new Guid("4e1cec2d-f3f0-4387-8e06-8baf2946c940"), true, "Designer", "Designer" },
                    { new Guid("c473160a-bb6e-4d77-989a-c1cf878abb0e"), true, "Leader", "Leader" },
                    { new Guid("f4750ea3-3fa7-4bd4-9356-8154ca767504"), true, "Admin", "Admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("10573a6c-e034-4da6-bec8-b51f12262f7c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4e1cec2d-f3f0-4387-8e06-8baf2946c940"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c473160a-bb6e-4d77-989a-c1cf878abb0e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f4750ea3-3fa7-4bd4-9356-8154ca767504"));

            migrationBuilder.DropColumn(
                name: "RequestDescriptionFromCustomer",
                table: "Projects");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsActive", "RoleCode", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1e6fd561-9508-4ed7-86ba-f9bde4c27d68"), true, "Designer", "Người thiết kế" },
                    { new Guid("4938687b-e20e-4199-b2d0-8475ff2ee295"), true, "Admin", "Quản trị viên" },
                    { new Guid("4cec3911-8d7f-469d-a9b7-3efb49b88071"), true, "Leader", "Người đứng đầu" },
                    { new Guid("f40fcc24-d353-47b2-bf57-31611d8605ed"), true, "Employee", "Nhân viên" }
                });
        }
    }
}
