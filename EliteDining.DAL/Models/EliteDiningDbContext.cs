using System;
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

    public virtual DbSet<BillT> BillTs { get; set; }

    public virtual DbSet<ChefT> ChefTs { get; set; }

    public virtual DbSet<CustomerT> CustomerTs { get; set; }

    public virtual DbSet<EmployeeT> EmployeeTs { get; set; }

    public virtual DbSet<FoodT> FoodTs { get; set; }

    public virtual DbSet<ManagerT> ManagerTs { get; set; }

    public virtual DbSet<OrderT> OrderTs { get; set; }

    public virtual DbSet<PaymentT> PaymentTs { get; set; }

    public virtual DbSet<TableT> TableTs { get; set; }

    public virtual DbSet<WaiterT> WaiterTs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3FTMPVV\\SQL0;Database=EliteDiningDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillT>(entity =>
        {
            entity.HasKey(e => e.BillNo).HasName("BILL_PK");

            entity.ToTable("BILL_t");

            entity.Property(e => e.BillNo).ValueGeneratedNever();
            entity.Property(e => e.CustId).HasColumnName("CustID");

            entity.HasOne(d => d.Cust).WithMany(p => p.BillTs)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BILL_FK");
        });

        modelBuilder.Entity<ChefT>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CHEF_t");

            entity.Property(e => e.ChefId).HasColumnName("ChefID");
            entity.Property(e => e.DayOrNight)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Day_or_night");
            entity.Property(e => e.Station)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Chef).WithMany()
                .HasForeignKey(d => d.ChefId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CHEF_PK");
        });

        modelBuilder.Entity<CustomerT>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("CUSTOMER_PK");

            entity.ToTable("CUSTOMER_t");

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

            entity.HasOne(d => d.TableNoNavigation).WithMany(p => p.CustomerTs)
                .HasForeignKey(d => d.TableNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CUSTOMER_FK");
        });

        modelBuilder.Entity<EmployeeT>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("EMPLOYEE_PK");

            entity.ToTable("EMPLOYEE_t");

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
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

            entity.HasOne(d => d.Manager).WithMany(p => p.EmployeeTs)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EMPLOYEE_FK");
        });

        modelBuilder.Entity<FoodT>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("FOOD_PK");

            entity.ToTable("FOOD_t");

            entity.Property(e => e.FoodId)
                .ValueGeneratedNever()
                .HasColumnName("FoodID");
            entity.Property(e => e.ChefId).HasColumnName("ChefID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ManagerT>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("MANAGER_PK");

            entity.ToTable("MANAGER_t");

            entity.Property(e => e.ManagerId)
                .ValueGeneratedNever()
                .HasColumnName("ManagerID");
            entity.Property(e => e.MName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("M_Name");
        });

        modelBuilder.Entity<OrderT>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ORDER_t");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.OrderTime).HasColumnName("Order_time");
            entity.Property(e => e.WaiterId).HasColumnName("WaiterID");

            entity.HasOne(d => d.Cust).WithMany()
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDER_FK1");

            entity.HasOne(d => d.Food).WithMany()
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDER_FK3");

            entity.HasOne(d => d.Waiter).WithMany()
                .HasForeignKey(d => d.WaiterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_t_WAITER_t");
        });

        modelBuilder.Entity<PaymentT>(entity =>
        {
            entity.HasKey(e => e.PaymentNo).HasName("PAYMENT_PK");

            entity.ToTable("PAYMENT_t");

            entity.Property(e => e.PaymentNo).ValueGeneratedNever();
            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.Type)
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.HasOne(d => d.Cust).WithMany(p => p.PaymentTs)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAYMENT_t_CUSTOMER_t");
        });

        modelBuilder.Entity<TableT>(entity =>
        {
            entity.HasKey(e => e.TableNo).HasName("TABLE_PK");

            entity.ToTable("TABLE_t");

            entity.Property(e => e.TableNo).ValueGeneratedNever();
            entity.Property(e => e.AvailableSeats).HasColumnName("Available_seats");
            entity.Property(e => e.WaiterId).HasColumnName("WaiterID");

            entity.HasOne(d => d.Waiter).WithMany(p => p.TableTs)
                .HasForeignKey(d => d.WaiterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TABLE_t_WAITER_t");
        });

        modelBuilder.Entity<WaiterT>(entity =>
        {
            entity.HasKey(e => e.WaiterId);

            entity.ToTable("WAITER_t");

            entity.Property(e => e.WaiterId)
                .ValueGeneratedNever()
                .HasColumnName("WaiterID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
