﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrintManagement.Infrastructure.DataContexts;

#nullable disable

namespace PrintManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("ShippingMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShippingMethodId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.DeliveryProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeliveryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("ProjectId");

                    b.ToTable("DeliveryProjects");
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

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

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
                            Id = new Guid("e97891bd-eb30-4c5a-9cce-190a45910392"),
                            IsActive = true,
                            RoleCode = "Admin",
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("53ca905e-32f4-4ecb-b80f-dc9cf11ff37e"),
                            IsActive = true,
                            RoleCode = "Manager",
                            RoleName = "Manager"
                        },
                        new
                        {
                            Id = new Guid("1cef52f3-8f3e-4a86-9813-ddae4b960dad"),
                            IsActive = true,
                            RoleCode = "Leader",
                            RoleName = "Leader"
                        },
                        new
                        {
                            Id = new Guid("2af72283-6b1d-4962-8b2c-642a224c340e"),
                            IsActive = true,
                            RoleCode = "Designer",
                            RoleName = "Designer"
                        },
                        new
                        {
                            Id = new Guid("60da399e-f258-4711-b77e-28d1f6c3342e"),
                            IsActive = true,
                            RoleCode = "Deliver",
                            RoleName = "Deliver"
                        },
                        new
                        {
                            Id = new Guid("45c85867-370a-425a-8d93-d8dd1511d7c9"),
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

            modelBuilder.Entity("PrintManagement.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfMember")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5ce8a3d5-d64a-4da6-876b-17ea1d158f6b"),
                            CreateTime = new DateTime(2024, 4, 14, 20, 7, 34, 767, DateTimeKind.Local).AddTicks(7140),
                            Description = "Phòng ban kinh doanh",
                            IsActive = true,
                            ManagerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Sales",
                            NumberOfMember = 0,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("b5750299-122d-42bb-8423-3cf79991ac5a"),
                            CreateTime = new DateTime(2024, 4, 14, 20, 7, 34, 767, DateTimeKind.Local).AddTicks(7162),
                            Description = "Phòng ban kỹ thuật",
                            IsActive = true,
                            ManagerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Technical",
                            NumberOfMember = 0,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7e950f76-320a-4037-865a-73e986009e45"),
                            CreateTime = new DateTime(2024, 4, 14, 20, 7, 34, 767, DateTimeKind.Local).AddTicks(7164),
                            Description = "Phòng ban giao hàng",
                            IsActive = true,
                            ManagerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Delivery",
                            NumberOfMember = 0,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
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

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

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

                    b.HasOne("PrintManagement.Domain.Entities.ShippingMethod", null)
                        .WithMany("Deliveries")
                        .HasForeignKey("ShippingMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.DeliveryProject", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.Delivery", "Delivery")
                        .WithMany("DeliveryProjects")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrintManagement.Domain.Entities.Project", "Project")
                        .WithMany("DeliveryProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

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
                        .WithMany("Permissions")
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

            modelBuilder.Entity("PrintManagement.Domain.Entities.User", b =>
                {
                    b.HasOne("PrintManagement.Domain.Entities.Team", "Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Delivery");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.Delivery", b =>
                {
                    b.Navigation("DeliveryProjects");
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

                    b.Navigation("DeliveryProjects");

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

            modelBuilder.Entity("PrintManagement.Domain.Entities.Team", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PrintManagement.Domain.Entities.User", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
