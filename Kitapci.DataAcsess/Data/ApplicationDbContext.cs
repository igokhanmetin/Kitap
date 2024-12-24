using Kitapci.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kitapci.DataAcsess.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kategori>().HasData(
                new Kategori { Id=1,Ad="Roman",DisplayOrder=1},
                new Kategori { Id=2,Ad="Hikaye",DisplayOrder=2},
                new Kategori { Id=3,Ad="Tarih",DisplayOrder=3},
                new Kategori { Id=4,Ad="Kişisel Gelişim",DisplayOrder=4},
                new Kategori { Id=5,Ad="Şiir",DisplayOrder=5}
                );
            modelBuilder.Entity<Kitap>().HasData(
                new Kitap
                {
                    Id = 1,
                    Baslik = "Martin Eden",
                    Yazar = "Jack London",
                    Aciklama = "Martin Eden, Amerikalı gazeteci ve roman yazarı Jack London’ın 33 yaşındayken yazdığı ve ilk kez 1909 yılında yayımlanan, yazarın olgunluk çağı eserlerinin en başarılılarından kabul edilen, künstlerroman geleneğinde yazılmış, Martin Eden’ın aşkı uğruna kaba, genç bir deniz işçisinden ünlü ve rafine bir yazara dönüşüm sürecini anlatan romanıdır.",
                    ISBN = "9786053322122",
                    ListeFiyati = 99,
                    Fiyat = 90,
                    Fiyat50 = 85,
                    Fiyat100 = 80,
                    KategoriId=1,
                    ImageUrl=""
                },
                new Kitap
                {
                    Id = 2,
                    Baslik = "1984",
                    Yazar = "George Orwell",
                    Aciklama = "1984 kitabı, İngiliz filozof ve yazar George Orwell tarafından kaleme alınmış, 1984 kitap konusu olarak 20. yüzyılın en önemli distopya örneklerinden biri olmuştur. George Orwell, 1948 yılında tamamladığı ve geleceğe dair karamsar bir kurgu geliştirerek gelecek hakkında insanlığı uyarmayı amaçlamıştır. ",
                    ISBN = "9789750718533",
                    ListeFiyati = 40,
                    Fiyat = 30,
                    Fiyat50 = 25,
                    Fiyat100 = 20,
                    KategoriId = 1,
                    ImageUrl = ""

                },
                new Kitap
                {
                    Id = 3,
                    Baslik = "Hasretinden Prangalar Eskittim",
                    Yazar = "Ahmed Arif",
                    Aciklama = "Türk edebiyatının unutulmaz şairlerinden Ahmet Arif, en sevilen şiirlerinin bir araya geldiği Hasretinden Prangalar Eskittim kitabı ile edebiyatseverlerin gönlünde taht kuruyor.",
                    ISBN = "RITO5555501",
                    ListeFiyati = 55,
                    Fiyat = 50,
                    Fiyat50 = 40,
                    Fiyat100 = 35,
                    KategoriId = 2,
                    ImageUrl = ""
                },
                new Kitap
                {
                    Id = 4,
                    Baslik = "Ben Sana Mecburum",
                    Yazar = "Attila İlhan",
                    Aciklama = "Bizi en ince yerimizden yakalıyor hep; birimizi, bazılarımızı değil, hepimizi…",
                    ISBN = "WS3333333301",
                    ListeFiyati = 70,
                    Fiyat = 65,
                    Fiyat50 = 60,
                    Fiyat100 = 55,
                    KategoriId = 2,
                    ImageUrl = ""
                },
                new Kitap
                {
                    Id = 5,
                    Baslik = "Yeni Dünya",
                    Yazar = "Sabahattin Ali",
                    Aciklama = "İstasyondan kalkıp vilayet merkezine giden kamyon, iki saat kadar sarstıktan sonra, beni gideceğim köye ayrılan yolun başında bıraktı. İki adım bile atacak halim yoktu. Çantamı yanıma koyarak, kenarlarından otlar fırlayan bir taşın üstüne oturdum. Kafamdaki uğultuyu dinlemeğe başladım.",
                    ISBN = "SOTJ1111111101",
                    ListeFiyati = 30,
                    Fiyat = 27,
                    Fiyat50 = 25,
                    Fiyat100 = 20,
                    KategoriId = 3,
                    ImageUrl = ""
                },
                new Kitap
                {
                    Id = 6,
                    Baslik = "Parasız Yatılı",
                    Yazar = "Füruzan",
                    Aciklama = "İlk yayımlandığı 1971 yılından beri okunan bir çağdaş klasik. \"Ana-kız\" temasından yola çıkarak genele ulaşan acılı bir öyküler kitabı.\n",
                    ISBN = "9789753634830",
                    ListeFiyati = 25,
                    Fiyat = 23,
                    Fiyat50 = 22,
                    Fiyat100 = 20,
                    KategoriId = 3,
                    ImageUrl = ""
                }
                );
        }
    }
}
