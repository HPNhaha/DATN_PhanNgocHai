using DoAnTotNghiep.Models;
using Microsoft.EntityFrameworkCore;
using DoAnTotNghiep.Models.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace DoAnTotNghiep.Data
{
    public class RestaurantContext:DbContext
    {
        private readonly AuditInterceptor _interceptor;
        public RestaurantContext(DbContextOptions<RestaurantContext> options, AuditInterceptor interceptor) : base(options)
        {
            _interceptor = interceptor;
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RevenueReport> RevenueReports { get; set; }
        public DbSet<Models.Table> Tables { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(p => p.role)
                .HasConversion<string>();
            modelBuilder.Entity<Menu>()
                .Property(p => p.category)
                .HasConversion<string>();
            modelBuilder.Entity<DoAnTotNghiep.Models.Table>()
                .Property(b => b.status)
                .HasConversion<string>();
            modelBuilder.Entity<Order>()
                .Property(a => a.status)
                .HasConversion<string>();
            modelBuilder.Entity<Payment>()
                .Property(a => a.status)
                .HasConversion<string>();
            modelBuilder.Entity<Payment>()
                .Property(b => b.method)
                .HasConversion<string>();
            modelBuilder.Entity<Reservation>()
                .Property(b => b.status)
                .HasConversion<string>();
        }
    }
}
