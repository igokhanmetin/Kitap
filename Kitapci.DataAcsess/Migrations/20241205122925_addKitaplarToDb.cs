using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kitapci.DataAcsess.Migrations
{
    /// <inheritdoc />
    public partial class addKitaplarToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yazar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListeFiyati = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Fiyat50 = table.Column<double>(type: "float", nullable: false),
                    Fiyat100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Aciklama", "Baslik", "Fiyat", "Fiyat100", "Fiyat50", "ISBN", "ListeFiyati", "Yazar" },
                values: new object[,]
                {
                    { 1, "Martin Eden, Amerikalı gazeteci ve roman yazarı Jack London’ın 33 yaşındayken yazdığı ve ilk kez 1909 yılında yayımlanan, yazarın olgunluk çağı eserlerinin en başarılılarından kabul edilen, künstlerroman geleneğinde yazılmış, Martin Eden’ın aşkı uğruna kaba, genç bir deniz işçisinden ünlü ve rafine bir yazara dönüşüm sürecini anlatan romanıdır.", "Martin Eden", 90.0, 80.0, 85.0, "9786053322122", 99.0, "Jack London" },
                    { 2, "1984 kitabı, İngiliz filozof ve yazar George Orwell tarafından kaleme alınmış, 1984 kitap konusu olarak 20. yüzyılın en önemli distopya örneklerinden biri olmuştur. George Orwell, 1948 yılında tamamladığı ve geleceğe dair karamsar bir kurgu geliştirerek gelecek hakkında insanlığı uyarmayı amaçlamıştır. ", "1984", 30.0, 20.0, 25.0, "9789750718533", 40.0, "George Orwell" },
                    { 3, "Türk edebiyatının unutulmaz şairlerinden Ahmet Arif, en sevilen şiirlerinin bir araya geldiği Hasretinden Prangalar Eskittim kitabı ile edebiyatseverlerin gönlünde taht kuruyor.", "Hasretinden Prangalar Eskittim", 50.0, 35.0, 40.0, "RITO5555501", 55.0, "Ahmed Arif" },
                    { 4, "Bizi en ince yerimizden yakalıyor hep; birimizi, bazılarımızı değil, hepimizi…", "Ben Sana Mecburum", 65.0, 55.0, 60.0, "WS3333333301", 70.0, "Attila İlhan" },
                    { 5, "İstasyondan kalkıp vilayet merkezine giden kamyon, iki saat kadar sarstıktan sonra, beni gideceğim köye ayrılan yolun başında bıraktı. İki adım bile atacak halim yoktu. Çantamı yanıma koyarak, kenarlarından otlar fırlayan bir taşın üstüne oturdum. Kafamdaki uğultuyu dinlemeğe başladım.", "Yeni Dünya", 27.0, 20.0, 25.0, "SOTJ1111111101", 30.0, "Sabahattin Ali" },
                    { 6, "İlk yayımlandığı 1971 yılından beri okunan bir çağdaş klasik. \"Ana-kız\" temasından yola çıkarak genele ulaşan acılı bir öyküler kitabı.\n", "Parasız Yatılı", 23.0, 20.0, 22.0, "9789753634830", 25.0, "Füruzan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitaplar");
        }
    }
}
