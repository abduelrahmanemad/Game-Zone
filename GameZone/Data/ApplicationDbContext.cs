using GameZone.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Device> Devices { get; set; } = default!;
        public DbSet<GameDevice> GameDevices { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDevice>()
                .HasKey(gd => new { gd.GameId, gd.DeviceId });
            base.OnModelCreating(modelBuilder);
        }

    }
}
