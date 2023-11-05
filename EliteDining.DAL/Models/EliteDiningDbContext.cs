﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EliteDining.DAL.Models;

public partial class EliteDiningDbContext : DbContext
{
    public EliteDiningDbContext()
    {
    }

    public EliteDiningDbContext(DbContextOptions<EliteDiningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3FTMPVV\\SQL0;Database=EliteDiningDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillNo).HasName("BILL_PK");

            entity.ToTable("BILL");

            entity.Property(e => e.BillNo).ValueGeneratedNever();
            entity.Property(e => e.CustId).HasColumnName("CustID");

            entity.HasOne(d => d.Cust).WithMany(p => p.Bills)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BILL_FK");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("CUSTOMER_PK");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustId)
                .ValueGeneratedNever()
                .HasColumnName("CustID");
            entity.Property(e => e.CName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("C_Name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.TableNoNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.TableNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CUSTOMER_FK");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("EMPLOYEE_PK");

            entity.ToTable("EMPLOYEE");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.DateHired)
                .HasColumnType("date")
                .HasColumnName("Date_hired");
            entity.Property(e => e.EName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("E_Name");
            entity.Property(e => e.HourlyPay).HasColumnName("Hourly_pay");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_EMPLOYEE_t_ROLE_t");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("FOOD_PK");

            entity.ToTable("FOOD");

            entity.Property(e => e.FoodId)
                .ValueGeneratedNever()
                .HasColumnName("FoodID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Foods)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FOOD_t_EMPLOYEE_t");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ORDER");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.OrderTime).HasColumnName("Order_time");

            entity.HasOne(d => d.Cust).WithMany()
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDER_FK1");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_t_EMPLOYEE_t");

            entity.HasOne(d => d.Food).WithMany()
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDER_FK3");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentNo).HasName("PAYMENT_PK");

            entity.ToTable("PAYMENT");

            entity.Property(e => e.PaymentNo).ValueGeneratedNever();
            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.Type)
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.HasOne(d => d.Cust).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAYMENT_t_CUSTOMER_t");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_ROLE_t");

            entity.ToTable("ROLE");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.IsChef).HasColumnName("isChef");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableNo).HasName("TABLE_PK");

            entity.ToTable("TABLE");

            entity.Property(e => e.TableNo).ValueGeneratedNever();
            entity.Property(e => e.AvailableSeats).HasColumnName("Available_seats");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Tables)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TABLE_t_EMPLOYEE_t");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
