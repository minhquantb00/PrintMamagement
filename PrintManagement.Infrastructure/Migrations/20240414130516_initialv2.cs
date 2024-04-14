using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    public partial class initialv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Projects_ProjectId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_EmployeeId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmails_Users_UserId",
                table: "ConfirmEmails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFeedbacks_Projects_ProjectId",
                table: "CustomerFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFeedbacks_Users_UserFeedbackId",
                table: "CustomerFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Customers_CustomerId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_ShippingMethods_ShippingMethodId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProjects_Deliveries_DeliveryId",
                table: "DeliveryProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProjects_Projects_ProjectId",
                table: "DeliveryProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Projects_ProjectId",
                table: "Designs");

            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Users_DesignerId",
                table: "Designs");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportCoupons_ResourcePropertyDetails_ResourcePropertyDetailId",
                table: "ImportCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportCoupons_Users_EmployeeId",
                table: "ImportCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintJobs_Designs_DesignId",
                table: "PrintJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_LeaderId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceForPrintJobs_PrintJobs_PrintJobId",
                table: "ResourceForPrintJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceForPrintJobs_Resources_ResourceId",
                table: "ResourceForPrintJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceProperties_Resources_ResourceId",
                table: "ResourceProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourcePropertyDetails_ResourceProperties_ResourcePropertyId",
                table: "ResourcePropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Team_TeamId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("05d9bf2f-a860-45e5-a98a-ed2d2842ed85"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("243bf441-5c6f-415b-9434-acca8f5d8cb5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("354efc0a-39f9-4f23-8d23-8dde9999de26"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("630acfee-7322-43db-9f03-9894ba4d8ca0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9229c553-0d05-4843-9592-b31411e79963"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bf6099e1-d67d-4f4e-887a-74b5c02f41c8"));

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Projects_ProjectId",
                table: "Bills",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_EmployeeId",
                table: "Bills",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmails_Users_UserId",
                table: "ConfirmEmails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFeedbacks_Projects_ProjectId",
                table: "CustomerFeedbacks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFeedbacks_Users_UserFeedbackId",
                table: "CustomerFeedbacks",
                column: "UserFeedbackId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Customers_CustomerId",
                table: "Deliveries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_ShippingMethods_ShippingMethodId",
                table: "Deliveries",
                column: "ShippingMethodId",
                principalTable: "ShippingMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProjects_Deliveries_DeliveryId",
                table: "DeliveryProjects",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProjects_Projects_ProjectId",
                table: "DeliveryProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Projects_ProjectId",
                table: "Designs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Users_DesignerId",
                table: "Designs",
                column: "DesignerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCoupons_ResourcePropertyDetails_ResourcePropertyDetailId",
                table: "ImportCoupons",
                column: "ResourcePropertyDetailId",
                principalTable: "ResourcePropertyDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCoupons_Users_EmployeeId",
                table: "ImportCoupons",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrintJobs_Designs_DesignId",
                table: "PrintJobs",
                column: "DesignId",
                principalTable: "Designs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_LeaderId",
                table: "Projects",
                column: "LeaderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceForPrintJobs_PrintJobs_PrintJobId",
                table: "ResourceForPrintJobs",
                column: "PrintJobId",
                principalTable: "PrintJobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceForPrintJobs_Resources_ResourceId",
                table: "ResourceForPrintJobs",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceProperties_Resources_ResourceId",
                table: "ResourceProperties",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourcePropertyDetails_ResourceProperties_ResourcePropertyId",
                table: "ResourcePropertyDetails",
                column: "ResourcePropertyId",
                principalTable: "ResourceProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Projects_ProjectId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_EmployeeId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmails_Users_UserId",
                table: "ConfirmEmails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFeedbacks_Projects_ProjectId",
                table: "CustomerFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFeedbacks_Users_UserFeedbackId",
                table: "CustomerFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Customers_CustomerId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_ShippingMethods_ShippingMethodId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProjects_Deliveries_DeliveryId",
                table: "DeliveryProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProjects_Projects_ProjectId",
                table: "DeliveryProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Projects_ProjectId",
                table: "Designs");

            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Users_DesignerId",
                table: "Designs");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportCoupons_ResourcePropertyDetails_ResourcePropertyDetailId",
                table: "ImportCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportCoupons_Users_EmployeeId",
                table: "ImportCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintJobs_Designs_DesignId",
                table: "PrintJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_LeaderId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceForPrintJobs_PrintJobs_PrintJobId",
                table: "ResourceForPrintJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceForPrintJobs_Resources_ResourceId",
                table: "ResourceForPrintJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceProperties_Resources_ResourceId",
                table: "ResourceProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourcePropertyDetails_ResourceProperties_ResourcePropertyId",
                table: "ResourcePropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

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

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsActive", "RoleCode", "RoleName" },
                values: new object[,]
                {
                    { new Guid("05d9bf2f-a860-45e5-a98a-ed2d2842ed85"), true, "Manager", "Manager" },
                    { new Guid("243bf441-5c6f-415b-9434-acca8f5d8cb5"), true, "Deliver", "Deliver" },
                    { new Guid("354efc0a-39f9-4f23-8d23-8dde9999de26"), true, "Leader", "Leader" },
                    { new Guid("630acfee-7322-43db-9f03-9894ba4d8ca0"), true, "Designer", "Designer" },
                    { new Guid("9229c553-0d05-4843-9592-b31411e79963"), true, "Employee", "Employee" },
                    { new Guid("bf6099e1-d67d-4f4e-887a-74b5c02f41c8"), true, "Admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Projects_ProjectId",
                table: "Bills",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_EmployeeId",
                table: "Bills",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmails_Users_UserId",
                table: "ConfirmEmails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFeedbacks_Projects_ProjectId",
                table: "CustomerFeedbacks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFeedbacks_Users_UserFeedbackId",
                table: "CustomerFeedbacks",
                column: "UserFeedbackId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Customers_CustomerId",
                table: "Deliveries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_ShippingMethods_ShippingMethodId",
                table: "Deliveries",
                column: "ShippingMethodId",
                principalTable: "ShippingMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProjects_Deliveries_DeliveryId",
                table: "DeliveryProjects",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProjects_Projects_ProjectId",
                table: "DeliveryProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Projects_ProjectId",
                table: "Designs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Users_DesignerId",
                table: "Designs",
                column: "DesignerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCoupons_ResourcePropertyDetails_ResourcePropertyDetailId",
                table: "ImportCoupons",
                column: "ResourcePropertyDetailId",
                principalTable: "ResourcePropertyDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCoupons_Users_EmployeeId",
                table: "ImportCoupons",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrintJobs_Designs_DesignId",
                table: "PrintJobs",
                column: "DesignId",
                principalTable: "Designs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_LeaderId",
                table: "Projects",
                column: "LeaderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceForPrintJobs_PrintJobs_PrintJobId",
                table: "ResourceForPrintJobs",
                column: "PrintJobId",
                principalTable: "PrintJobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceForPrintJobs_Resources_ResourceId",
                table: "ResourceForPrintJobs",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceProperties_Resources_ResourceId",
                table: "ResourceProperties",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourcePropertyDetails_ResourceProperties_ResourcePropertyId",
                table: "ResourcePropertyDetails",
                column: "ResourcePropertyId",
                principalTable: "ResourceProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Team_TeamId",
                table: "Users",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");
        }
    }
}
