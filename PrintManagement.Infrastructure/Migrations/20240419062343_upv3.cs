using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    public partial class upv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryProjects");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliverId",
                table: "Deliveries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Deliveries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ConfirmReceiptOfGoodsFromCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfirmReceiptOfGoods = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmReceiptOfGoodsFromCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmReceiptOfGoodsFromCustomers_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DeliverId",
                table: "Deliveries",
                column: "DeliverId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ProjectId",
                table: "Deliveries",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmReceiptOfGoodsFromCustomers_DeliveryId",
                table: "ConfirmReceiptOfGoodsFromCustomers",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Projects_ProjectId",
                table: "Deliveries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_DeliverId",
                table: "Deliveries",
                column: "DeliverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Projects_ProjectId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_DeliverId",
                table: "Deliveries");

            migrationBuilder.DropTable(
                name: "ConfirmReceiptOfGoodsFromCustomers");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_DeliverId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_ProjectId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "DeliverId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Deliveries");

            migrationBuilder.CreateTable(
                name: "DeliveryProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProjects_DeliveryId",
                table: "DeliveryProjects",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProjects_ProjectId",
                table: "DeliveryProjects",
                column: "ProjectId");
        }
    }
}
