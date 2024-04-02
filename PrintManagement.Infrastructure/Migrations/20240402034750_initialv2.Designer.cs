﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrintManagement.Infrastructure.DataContexts;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240402034750_initialv2")]
    partial class initialv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PrintManagement.Domain.Entities.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BillStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TradingCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ConfirmEmail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ConfirmEmails");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.CustomerFeedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeedbackContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FeedbackTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResponseByCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResponseTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserFeedbackId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserFeedbackId");

                    b.ToTable("CustomerFeedbacks");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActualDeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeliveryStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("EstimateDeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShippingMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ShippingMethodId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Design", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApproverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DesignImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DesignStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("DesignTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DesignerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DesignerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Designs");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ImportCoupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ResourcePropertyDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TradingCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ResourcePropertyDetailId");

                    b.ToTable("ImportCoupons");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.KeyPerformanceIndicators", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("AchieveKPI")
                        .HasColumnType("bit");

                    b.Property<int>("ActuallyAchieved")
                        .HasColumnType("int");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IndicatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Period")
                        .HasColumnType("int");

                    b.Property<int>("Target")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("KeyPerformanceIndicators");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Permissions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.PrintJob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DesignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("PrintJobStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DesignId");

                    b.ToTable("PrintJobs");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActualEndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("LeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Progress")
                        .HasColumnType("float");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectStatus")
                        .HasColumnType("int");

                    b.Property<string>("RequestDescriptionFromCustomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LeaderId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResourceStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ResourceForPrintJob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PrintJobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PrintJobId");

                    b.HasIndex("ResourceId");

                    b.ToTable("ResourceForPrintJobs");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ResourceProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResourcePropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("ResourceProperties");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ResourcePropertyDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ResourcePropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResourcePropertyId");

                    b.ToTable("ResourcePropertyDetails");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f4750ea3-3fa7-4bd4-9356-8154ca767504"),
                            IsActive = true,
                            RoleCode = "Admin",
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("c473160a-bb6e-4d77-989a-c1cf878abb0e"),
                            IsActive = true,
                            RoleCode = "Leader",
                            RoleName = "Leader"
                        },
                        new
                        {
                            Id = new Guid("4e1cec2d-f3f0-4387-8e06-8baf2946c940"),
                            IsActive = true,
                            RoleCode = "Designer",
                            RoleName = "Designer"
                        },
                        new
                        {
                            Id = new Guid("10573a6c-e034-4da6-bec8-b51f12262f7c"),
                            IsActive = true,
                            RoleCode = "Employee",
                            RoleName = "Employee"
                        });
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ShippingMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ShippingMethodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShippingMethods");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Bill", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.Customer", null)
                        .WithMany("Bills")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.User", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ConfirmEmail", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.CustomerFeedback", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.Project", "Project")
                        .WithMany("CustomerFeedbacks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.User", "UserFeedback")
                        .WithMany()
                        .HasForeignKey("UserFeedbackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("UserFeedback");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Delivery", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.Customer", "Customer")
                        .WithMany("Delivery")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.Project", "Project")
                        .WithMany("Deliveries")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.ShippingMethod", null)
                        .WithMany("Deliveries")
                        .HasForeignKey("ShippingMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Design", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.User", "Designer")
                        .WithMany()
                        .HasForeignKey("DesignerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.Project", "Project")
                        .WithMany("Designs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Designer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ImportCoupon", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.User", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.ResourcePropertyDetail", "ResourcePropertyDetail")
                        .WithMany("ImportCoupons")
                        .HasForeignKey("ResourcePropertyDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("ResourcePropertyDetail");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.KeyPerformanceIndicators", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Permissions", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.PrintJob", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.Design", "Design")
                        .WithMany("PrintJobs")
                        .HasForeignKey("DesignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Design");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Project", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.Customer", "Customer")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.User", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ResourceForPrintJob", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.PrintJob", "PrintJob")
                        .WithMany("ResourceForPrints")
                        .HasForeignKey("PrintJobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.Resource", "Resource")
                        .WithMany("ResourceForPrintJobs")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrintJob");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ResourceProperty", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.Resource", "Resource")
                        .WithMany("ResourceProperties")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ResourcePropertyDetail", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.ResourceProperty", "ResourceProperty")
                        .WithMany("ResourcePropertyDetails")
                        .HasForeignKey("ResourcePropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResourceProperty");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Delivery");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Design", b =>
                {
                    b.Navigation("PrintJobs");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.PrintJob", b =>
                {
                    b.Navigation("ResourceForPrints");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Project", b =>
                {
                    b.Navigation("CustomerFeedbacks");

                    b.Navigation("Deliveries");

                    b.Navigation("Designs");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Resource", b =>
                {
                    b.Navigation("ResourceForPrintJobs");

                    b.Navigation("ResourceProperties");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ResourceProperty", b =>
                {
                    b.Navigation("ResourcePropertyDetails");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ResourcePropertyDetail", b =>
                {
                    b.Navigation("ImportCoupons");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.ShippingMethod", b =>
                {
                    b.Navigation("Deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
