using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    public partial class initialv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Projects_ProjectId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_ProjectId",
                table: "Deliveries");

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
                name: "ProjectId",
                table: "Deliveries");

            migrationBuilder.CreateTable(
                name: "DeliveryProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryProjects_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProjects_DeliveryId",
                table: "DeliveryProjects",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProjects_ProjectId",
                table: "DeliveryProjects",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryProjects");

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

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Deliveries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ProjectId",
                table: "Deliveries",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Projects_ProjectId",
                table: "Deliveries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
