using KonyvtarWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KonyvtarWebAPI.Data
{
    public class KonyvtarDbContext : DbContext
    {
        public KonyvtarDbContext(DbContextOptions<KonyvtarDbContext> options) : base(options)
        {
        }
        public DbSet<Konyv> Konyvek { get; set; }
        public DbSet<Szerzo> Szerzok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Konyv>()
                .HasOne(s => s.Szerzo)
                .WithMany(k => k.Konyvei)
                .HasForeignKey(k => k.SzerzoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Konyv>()
                .HasData(
                    new Konyv { Id = 1, Cim = "Példakönyv 1", KiadasEve = 2020, SzerzoId = 1 },
                    new Konyv { Id = 2, Cim = "Példakönyv 2", KiadasEve = 2021, SzerzoId = 2 },
                    new Konyv { Id = 3, Cim = "Példakönyv 3", KiadasEve = 2022, SzerzoId = 1 }
                );
            modelBuilder.Entity<Szerzo>()
                .HasData(
                    new Szerzo { Id = 1, Nev = "Kovács János" },
                    new Szerzo { Id = 2, Nev = "Nagy Péter" }
                );

        }
    }
}
