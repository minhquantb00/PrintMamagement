using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserStatus_UserStatusId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserStatus");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserStatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserStatusId",
                table: "Users");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserStatusId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStatusId",
                table: "Users",
                column: "UserStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserStatus_UserStatusId",
                table: "Users",
                column: "UserStatusId",
                principalTable: "UserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
