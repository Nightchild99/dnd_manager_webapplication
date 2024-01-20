using dnd_manager_webapplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dnd_manager_webapplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<SiteUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Character>()
                .HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(builder);

            builder.Entity<Character>()
                .HasOne(t => t.Background)
                .WithMany(b => b.Characters)
                .HasForeignKey(t => t.BackgroundID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Background>().HasData(new Background[]
            {
                new Background(){ID=1,Name="Forgotten Realms"},
                new Background(){ID=2,Name="Eberron"},
                new Background(){ID=3,Name="Dragonlance"},
                new Background(){ID=4,Name="Greyhawk"},
                new Background(){ID=5,Name="Ravenloft"},
                new Background(){ID=6,Name="Planescape"},
                new Background(){ID=7,Name="Spelljammer"},
                new Background(){ID=8,Name="Eberron"}
            });
        }
    }
}