using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KitapciRazor.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        [DisplayName("Kategori İsmi")]
        public string Ad { get; set; } = string.Empty;

        [DisplayName("Kategori Numarası")]
        [Range(1, 100, ErrorMessage = "Lütfen 1 ile 100 arasında bir değer giriniz.")]
        public int DisplayOrder { get; set; }
    }
}
