﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RadicalMotor.Models;

#nullable disable

namespace RadicalMotorAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240422040449_Initials")]
    partial class Initials
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RadicalMotor.Models.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AccountTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstallmentContractId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AccountId");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("RadicalMotor.Models.AccountType", b =>
                {
                    b.Property<string>("AccountTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AccountTypeId");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("RadicalMotor.Models.Appointment", b =>
                {
                    b.Property<string>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentId");

                    b.HasIndex("AccountId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("RadicalMotor.Models.AppointmentDetail", b =>
                {
                    b.Property<string>("AppointmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ServiceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentDetails");
                });

            modelBuilder.Entity("RadicalMotor.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RadicalMotor.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RadicalMotor.Models.InstallmentContract", b =>
                {
                    b.Property<string>("InstallmentContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChassisNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InstallmentPlanId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("MonthlyInstallment")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("InstallmentContractId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ChassisNumber");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InstallmentPlanId");

                    b.ToTable("InstallmentContracts");
                });

            modelBuilder.Entity("RadicalMotor.Models.InstallmentHistory", b =>
                {
                    b.Property<string>("InstallmentHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InstallmentContractId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NextPaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstallmentHistoryId");

                    b.HasIndex("AccountId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InstallmentContractId");

                    b.ToTable("InstallmentHistorys");
                });

            modelBuilder.Entity("RadicalMotor.Models.InstallmentNotification", b =>
                {
                    b.Property<string>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstallmentContractId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NotificationContent")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("NotificationId");

                    b.HasIndex("AccountId");

                    b.HasIndex("InstallmentContractId");

                    b.ToTable("InstallmentNotifications");
                });

            modelBuilder.Entity("RadicalMotor.Models.InstallmentPlan", b =>
                {
                    b.Property<string>("InstallmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tenure")
                        .HasColumnType("int");

                    b.HasKey("InstallmentTypeId");

                    b.ToTable("InstallmentPlans");
                });

            modelBuilder.Entity("RadicalMotor.Models.Promotion", b =>
                {
                    b.Property<string>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PromotionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PromotionId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("RadicalMotor.Models.PromotionDetail", b =>
                {
                    b.Property<string>("InstallmentContractId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PromotionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ActualDiscount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("InstallmentContractId", "PromotionId");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionDetails");
                });

            modelBuilder.Entity("RadicalMotor.Models.Service", b =>
                {
                    b.Property<string>("ServiceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("RadicalMotor.Models.Supplier", b =>
                {
                    b.Property<string>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("RadicalMotor.Models.Vehicle", b =>
                {
                    b.Property<string>("ChassisNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("VehicleTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ChassisNumber");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("RadicalMotor.Models.VehicleImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<string>("ChassisNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("ChassisNumber");

                    b.ToTable("VehicleImages");
                });

            modelBuilder.Entity("RadicalMotor.Models.VehicleType", b =>
                {
                    b.Property<string>("VehicleTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SupplierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VehicleTypeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("RadicalMotor.Models.Account", b =>
                {
                    b.HasOne("RadicalMotor.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RadicalMotor.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId");

                    b.Navigation("AccountType");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RadicalMotor.Models.Appointment", b =>
                {
                    b.HasOne("RadicalMotor.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("RadicalMotor.Models.AppointmentDetail", b =>
                {
                    b.HasOne("RadicalMotor.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RadicalMotor.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("RadicalMotor.Models.InstallmentContract", b =>
                {
                    b.HasOne("RadicalMotor.Models.Account", null)
                        .WithMany("InstallmentContracts")
                        .HasForeignKey("AccountId");

                    b.HasOne("RadicalMotor.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("ChassisNumber")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RadicalMotor.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RadicalMotor.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RadicalMotor.Models.InstallmentPlan", "InstallmentPlan")
                        .WithMany()
                        .HasForeignKey("InstallmentPlanId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("InstallmentPlan");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("RadicalMotor.Models.InstallmentHistory", b =>
                {
                    b.HasOne("RadicalMotor.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RadicalMotor.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RadicalMotor.Models.InstallmentContract", "InstallmentContract")
                        .WithMany()
                        .HasForeignKey("InstallmentContractId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Employee");

                    b.Navigation("InstallmentContract");
                });

            modelBuilder.Entity("RadicalMotor.Models.InstallmentNotification", b =>
                {
                    b.HasOne("RadicalMotor.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RadicalMotor.Models.InstallmentContract", "InstallmentContract")
                        .WithMany()
                        .HasForeignKey("InstallmentContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("InstallmentContract");
                });

            modelBuilder.Entity("RadicalMotor.Models.PromotionDetail", b =>
                {
                    b.HasOne("RadicalMotor.Models.InstallmentContract", "InstallmentContract")
                        .WithMany()
                        .HasForeignKey("InstallmentContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RadicalMotor.Models.Promotion", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InstallmentContract");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("RadicalMotor.Models.Vehicle", b =>
                {
                    b.HasOne("RadicalMotor.Models.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("RadicalMotor.Models.VehicleImage", b =>
                {
                    b.HasOne("RadicalMotor.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleImages")
                        .HasForeignKey("ChassisNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("RadicalMotor.Models.VehicleType", b =>
                {
                    b.HasOne("RadicalMotor.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("RadicalMotor.Models.Account", b =>
                {
                    b.Navigation("InstallmentContracts");
                });

            modelBuilder.Entity("RadicalMotor.Models.Customer", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("RadicalMotor.Models.Vehicle", b =>
                {
                    b.Navigation("VehicleImages");
                });
#pragma warning restore 612, 618
        }
    }
}
