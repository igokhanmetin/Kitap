using KitapciRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace KitapciRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori { Id = 1, Ad = "Roman", DisplayOrder = 1 },
                new Kategori { Id = 2, Ad = "Hikaye", DisplayOrder = 2 },
                new Kategori { Id = 3, Ad = "Tarih", DisplayOrder = 3 },
                new Kategori { Id = 4, Ad = "Kişisel Gelişim", DisplayOrder = 4 },
                new Kategori { Id = 5, Ad = "Şiir", DisplayOrder = 5 }
                );
        }
    }
}
