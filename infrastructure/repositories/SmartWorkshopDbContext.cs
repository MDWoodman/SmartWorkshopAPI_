using Microsoft.EntityFrameworkCore;

namespace SmartWorkshopAPI.infrastructure.repositories
{
    public class SmartWorkshopDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=smartworkshop.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<domain.entities.Order>()
                .HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<domain.entities.OrderItem>()
                .Property(oi => oi.OrderItemId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<domain.entities.Order>()
                .Property(o => o.OrderId)
                .ValueGeneratedOnAdd();

           
            modelBuilder.Entity<domain.entities.Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<domain.entities.OrderItem>()
                .HasKey(oi => oi.OrderItemId);

            
                             
        }
        public DbSet<domain.entities.Order> Orders { get; set; }
        public DbSet<domain.entities.OrderItem> OrderItems { get; set; }
    }
}
