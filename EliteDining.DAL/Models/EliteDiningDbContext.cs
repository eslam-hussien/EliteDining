using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EliteDining.DAL.Models;

public partial class EliteDiningDbContext : IdentityDbContext<ApplicationUser>
{
    public EliteDiningDbContext()
    {
    }

    public EliteDiningDbContext(DbContextOptions<EliteDiningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3FTMPVV\\SQL0;Database=EliteDiningDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillNo).HasName("BILL_PK");

            entity.ToTable("BILL");

            entity.HasIndex(e => e.CustId, "IX_BILL_CustID");

            entity.Property(e => e.BillNo).ValueGeneratedNever();
            entity.Property(e => e.CustId).HasColumnName("CustID");

            entity.HasOne(d => d.Cust).WithMany(p => p.Bills)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BILL_FK");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.Cust).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_CUSTOMER");

            entity.HasOne(d => d.TableNoNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TableNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_TABLE");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.Message).HasColumnName("message");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("CUSTOMER_PK");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.CName)
                .HasMaxLength(50)
                .HasColumnName("C_Name");
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("EMPLOYEE_PK");

            entity.ToTable("EMPLOYEE");

            entity.HasIndex(e => e.RoleId, "IX_EMPLOYEE_RoleID");

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

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_ROLE_t");

            entity.ToTable("EmployeeROLE");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.IsChef).HasColumnName("isChef");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("FOOD_PK");

            entity.ToTable("FOOD");

            entity.HasIndex(e => e.EmployeeId, "IX_FOOD_EmployeeID");

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
            entity.ToTable("ORDER");

            entity.HasIndex(e => e.CustId, "IX_ORDER_CustID");

            entity.HasIndex(e => e.EmployeeId, "IX_ORDER_EmployeeID");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.OrderTime).HasColumnName("Order_time");

            entity.HasOne(d => d.Cust).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDER_FK1");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_ORDER_t_EMPLOYEE_t");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId);

            entity.ToTable("ORDER_DETAILS");

            entity.Property(e => e.FkFoodId).HasColumnName("FK_FoodID");
            entity.Property(e => e.FkOrderId).HasColumnName("FK_OrderID");

            entity.HasOne(d => d.FkFood).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.FkFoodId)
                .HasConstraintName("FK_ORDER_DETAILS_FOOD");

            entity.HasOne(d => d.FkOrder).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.FkOrderId)
                .HasConstraintName("FK_ORDER_DETAILS_ORDER");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentNo).HasName("PAYMENT_PK");

            entity.ToTable("PAYMENT");

            entity.HasIndex(e => e.CustId, "IX_PAYMENT_CustID");

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

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableNo).HasName("TABLE_PK");

            entity.ToTable("TABLE");

            entity.HasIndex(e => e.EmployeeId, "IX_TABLE_EmployeeID");

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
