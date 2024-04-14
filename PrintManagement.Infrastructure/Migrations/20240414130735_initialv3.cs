using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    public partial class initialv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("0e854122-695b-4566-b1e4-a7e0b4179910"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("37a17556-2f3f-4f77-8ef1-6555c1861eca"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("68cb4a00-ddd0-40cf-98e9-7c2795b31bf4"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsActive", "RoleCode", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1cef52f3-8f3e-4a86-9813-ddae4b960dad"), true, "Leader", "Leader" },
                    { new Guid("2af72283-6b1d-4962-8b2c-642a224c340e"), true, "Designer", "Designer" },
                    { new Guid("45c85867-370a-425a-8d93-d8dd1511d7c9"), true, "Employee", "Employee" },
                    { new Guid("53ca905e-32f4-4ecb-b80f-dc9cf11ff37e"), true, "Manager", "Manager" },
                    { new Guid("60da399e-f258-4711-b77e-28d1f6c3342e"), true, "Deliver", "Deliver" },
                    { new Guid("e97891bd-eb30-4c5a-9cce-190a45910392"), true, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreateTime", "Description", "IsActive", "ManagerId", "Name", "NumberOfMember", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("5ce8a3d5-d64a-4da6-876b-17ea1d158f6b"), new DateTime(2024, 4, 14, 20, 7, 34, 767, DateTimeKind.Local).AddTicks(7140), "Phòng ban kinh doanh", true, new Guid("00000000-0000-0000-0000-000000000000"), "Sales", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e950f76-320a-4037-865a-73e986009e45"), new DateTime(2024, 4, 14, 20, 7, 34, 767, DateTimeKind.Local).AddTicks(7164), "Phòng ban giao hàng", true, new Guid("00000000-0000-0000-0000-000000000000"), "Delivery", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5750299-122d-42bb-8423-3cf79991ac5a"), new DateTime(2024, 4, 14, 20, 7, 34, 767, DateTimeKind.Local).AddTicks(7162), "Phòng ban kỹ thuật", true, new Guid("00000000-0000-0000-0000-000000000000"), "Technical", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1cef52f3-8f3e-4a86-9813-ddae4b960dad"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2af72283-6b1d-4962-8b2c-642a224c340e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("45c85867-370a-425a-8d93-d8dd1511d7c9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("53ca905e-32f4-4ecb-b80f-dc9cf11ff37e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("60da399e-f258-4711-b77e-28d1f6c3342e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e97891bd-eb30-4c5a-9cce-190a45910392"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("5ce8a3d5-d64a-4da6-876b-17ea1d158f6b"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("7e950f76-320a-4037-865a-73e986009e45"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("b5750299-122d-42bb-8423-3cf79991ac5a"));

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreateTime", "Description", "IsActive", "ManagerId", "Name", "NumberOfMember", "UpdateTime" },
                values: new object[] { new Guid("0e854122-695b-4566-b1e4-a7e0b4179910"), new DateTime(2024, 4, 14, 20, 5, 15, 959, DateTimeKind.Local).AddTicks(4825), "Phòng ban giao hàng", true, new Guid("00000000-0000-0000-0000-000000000000"), "Delivery", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreateTime", "Description", "IsActive", "ManagerId", "Name", "NumberOfMember", "UpdateTime" },
                values: new object[] { new Guid("37a17556-2f3f-4f77-8ef1-6555c1861eca"), new DateTime(2024, 4, 14, 20, 5, 15, 959, DateTimeKind.Local).AddTicks(4808), "Phòng ban kỹ thuật", true, new Guid("00000000-0000-0000-0000-000000000000"), "Technical", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreateTime", "Description", "IsActive", "ManagerId", "Name", "NumberOfMember", "UpdateTime" },
                values: new object[] { new Guid("68cb4a00-ddd0-40cf-98e9-7c2795b31bf4"), new DateTime(2024, 4, 14, 20, 5, 15, 959, DateTimeKind.Local).AddTicks(4790), "Phòng ban kinh doanh", true, new Guid("00000000-0000-0000-0000-000000000000"), "Sales", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
