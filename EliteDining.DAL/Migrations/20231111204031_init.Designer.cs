﻿// <auto-generated />
using System;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EliteDining.DAL.Migrations
{
    [DbContext(typeof(EliteDiningDbContext))]
    [Migration("20231111204031_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EliteDining.DAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Bill", b =>
                {
                    b.Property<int>("BillNo")
                        .HasColumnType("int");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CustId")
                        .HasColumnType("int")
                        .HasColumnName("CustID");

                    b.HasKey("BillNo")
                        .HasName("BILL_PK");

                    b.HasIndex("CustId");

                    b.ToTable("BILL", (string)null);
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Customer", b =>
                {
                    b.Property<int>("CustId")
                        .HasColumnType("int")
                        .HasColumnName("CustID");

                    b.Property<string>("CName")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("C_Name");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("TableNo")
                        .HasColumnType("int");

                    b.HasKey("CustId")
                        .HasName("CUSTOMER_PK");

                    b.HasIndex("TableNo");

                    b.ToTable("CUSTOMER", (string)null);
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime?>("DateHired")
                        .HasColumnType("date")
                        .HasColumnName("Date_hired");

                    b.Property<string>("EName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("E_Name");

                    b.Property<int?>("HourlyPay")
                        .HasColumnType("int")
                        .HasColumnName("Hourly_pay");

                    b.Property<int?>("RoleId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.HasKey("EmployeeId")
                        .HasName("EMPLOYEE_PK");

                    b.HasIndex("RoleId");

                    b.ToTable("EMPLOYEE", (string)null);
                });

            modelBuilder.Entity("EliteDining.DAL.Models.EmployeeRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsChef")
                        .HasColumnType("bit")
                        .HasColumnName("isChef");

                    b.Property<bool?>("IsWaiter")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId")
                        .HasName("PK_ROLE_t");

                    b.ToTable("EmployeeRole", (string)null);
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int")
                        .HasColumnName("FoodID");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("FoodId")
                        .HasName("FOOD_PK");

                    b.HasIndex("EmployeeId");

                    b.ToTable("FOOD", (string)null);
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustId")
                        .HasColumnType("int")
                        .HasColumnName("CustID");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<int>("FoodId")
                        .HasColumnType("int")
                        .HasColumnName("FoodID");

                    b.Property<TimeSpan?>("OrderTime")
                        .HasColumnType("time")
                        .HasColumnName("Order_time");

                    b.HasKey("OrderId");

                    b.HasIndex("CustId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FoodId");

                    b.ToTable("ORDER", (string)null);
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Payment", b =>
                {
                    b.Property<int>("PaymentNo")
                        .HasColumnType("int");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CustId")
                        .HasColumnType("int")
                        .HasColumnName("CustID");

                    b.Property<string>("Type")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.HasKey("PaymentNo")
                        .HasName("PAYMENT_PK");

                    b.HasIndex("CustId");

                    b.ToTable("PAYMENT", (string)null);
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Table", b =>
                {
                    b.Property<int>("TableNo")
                        .HasColumnType("int");

                    b.Property<int?>("AvailableSeats")
                        .HasColumnType("int")
                        .HasColumnName("Available_seats");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.HasKey("TableNo")
                        .HasName("TABLE_PK");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TABLE", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Bill", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.Customer", "Cust")
                        .WithMany("Bills")
                        .HasForeignKey("CustId")
                        .IsRequired()
                        .HasConstraintName("BILL_FK");

                    b.Navigation("Cust");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Customer", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.Table", "TableNoNavigation")
                        .WithMany("Customers")
                        .HasForeignKey("TableNo")
                        .IsRequired()
                        .HasConstraintName("CUSTOMER_FK");

                    b.Navigation("TableNoNavigation");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Employee", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.EmployeeRole", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_EMPLOYEE_t_ROLE_t");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Food", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.Employee", "Employee")
                        .WithMany("Foods")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK_FOOD_t_EMPLOYEE_t");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Order", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.Customer", "Cust")
                        .WithMany("Orders")
                        .HasForeignKey("CustId")
                        .IsRequired()
                        .HasConstraintName("ORDER_FK1");

                    b.HasOne("EliteDining.DAL.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK_ORDER_t_EMPLOYEE_t");

                    b.HasOne("EliteDining.DAL.Models.Food", "Food")
                        .WithMany("Orders")
                        .HasForeignKey("FoodId")
                        .IsRequired()
                        .HasConstraintName("ORDER_FK3");

                    b.Navigation("Cust");

                    b.Navigation("Employee");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Payment", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.Customer", "Cust")
                        .WithMany("Payments")
                        .HasForeignKey("CustId")
                        .IsRequired()
                        .HasConstraintName("FK_PAYMENT_t_CUSTOMER_t");

                    b.Navigation("Cust");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Table", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.Employee", "Employee")
                        .WithMany("Tables")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK_TABLE_t_EMPLOYEE_t");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EliteDining.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EliteDining.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Employee", b =>
                {
                    b.Navigation("Foods");

                    b.Navigation("Orders");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.EmployeeRole", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Food", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EliteDining.DAL.Models.Table", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
