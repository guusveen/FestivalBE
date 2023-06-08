using Microsoft.EntityFrameworkCore;
using FestivalBE.Models;

namespace FestivalBE.Models
{
    public class FestiFactDbContext : DbContext
    {
        public FestiFactDbContext(DbContextOptions<FestiFactDbContext> options) : base(options) { }

        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Organisator> Organisators { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<Zaal> Zalen { get; set; }
        public DbSet<Voorstelling> Voorstellingen { get; set; }
        public DbSet<Artiest> Artiesten { get; set; }
        public DbSet<Bezoeker> Bezoekers { get; set; }
        public DbSet<VoorstellingFavoriet> VoorstellingFavorieten { get; set; }
        public DbSet<ArtiestFavoriet> ArtiestFavorieten { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => new { t.BezoekerId, t.VoorstellingId })
                .IsUnique();

            modelBuilder.Entity<ArtiestFavoriet>()
                .HasIndex(af => new { af.BezoekerId, af.ArtiestId })
                .IsUnique();

            modelBuilder.Entity<VoorstellingFavoriet>()
                .HasIndex(vf => new { vf.BezoekerId, vf.VoorstellingId })
                .IsUnique();

            modelBuilder.Entity<Rating>()
                .HasIndex(r => new { r.BezoekerId, r.VoorstellingId })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
