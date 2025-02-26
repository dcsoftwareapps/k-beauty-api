using Microsoft.EntityFrameworkCore;

namespace KBeautyApi.Models
{
    public class FidelityDbContext : DbContext
    {
        public FidelityDbContext(DbContextOptions<FidelityDbContext> options)
        : base(options) { }

        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;
        public DbSet<Level> Levels { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Store)
                .WithMany(s => s.Users)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Level>()
                .HasOne(u => u.Store)
                .WithMany(s => s.Levels)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
