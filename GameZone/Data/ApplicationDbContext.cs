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

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category { Id = 1, Name = "Action" },
                new Category { Id = 2, Name = "Adventure" },
                new Category { Id = 3, Name = "RPG" },
                new Category { Id = 4, Name = "Simulation" },
                new Category { Id = 5, Name = "Strategy" },
                new Category { Id = 6, Name = "Sports" },
                new Category { Id = 7, Name = "Puzzle" },
                new Category { Id = 8, Name = "Idle" },
                new Category { Id = 9, Name = "Casual" },
                new Category { Id = 10, Name = "Arcade" },
                new Category { Id = 11, Name = "Racing" },
                new Category { Id = 12, Name = "Horror" },
                new Category { Id = 13, Name = "Fantasy" },
                new Category { Id = 14, Name = "Sci-Fi" },
                new Category { Id = 15, Name = "MMO" },
                new Category { Id = 16, Name = "MOBA" },
                new Category { Id = 17, Name = "Battle Royale" },
                new Category { Id = 18, Name = "FPS" },
                new Category { Id = 19, Name = "TPS" },
                new Category { Id = 20, Name = "Survival" },
                new Category { Id = 21, Name = "Open World" },
                new Category { Id = 22, Name = "MMORPG" },
                new Category { Id = 23, Name = "RTS" },
                new Category { Id = 24, Name = "TBS" },
                new Category { Id = 25, Name = "Card" },
                new Category { Id = 26, Name = "Board" },
                new Category { Id = 27, Name = "Trivia" },
                new Category { Id = 28, Name = "Word" },
                new Category { Id = 29, Name = "Music" },
                new Category { Id = 30, Name = "Educational" },
                new Category { Id = 31, Name = "Family" },
                new Category { Id = 32, Name = "Casino"}
            });

            modelBuilder.Entity<Device>().HasData(new Device[]
            {
                new Device { Id = 1, Name = "PC" , Icon = "bi bi-pc-display" },
                new Device { Id = 2, Name = "PlayStation" , Icon="bi bi-playstation" },
                new Device { Id = 3, Name = "Xbox" , Icon= "bi bi-xbox" },
                new Device { Id = 4, Name = "Nintendo", Icon= "bi bi-nintendo-switch" },
            });



            modelBuilder.Entity<GameDevice>()
                .HasKey(gd => new { gd.GameId, gd.DeviceId });
            base.OnModelCreating(modelBuilder);
        }

    }
}
