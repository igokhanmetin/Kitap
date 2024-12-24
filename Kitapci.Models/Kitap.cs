using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Kitapci.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Baslik { get; set; } 
        public string Aciklama { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Yazar { get; set; } 
        [Required]
        [Display(Name = "Lİste Fiyati ")]
        [Range(1,1000)]
        public double ListeFiyati { get; set; }
        [Required]
        [Display(Name = "Fiyat araligi 1-50 ")]
        [Range(1, 1000)]
        public double Fiyat { get; set; }
        [Required]
        [Display(Name = "Fiyat Araligi 50+")]
        [Range(1, 1000)]
        public double Fiyat50 { get; set; }
        [Required]
        [Display(Name = "Fiyat Araligi 100+")]
        [Range(1, 1000)]
        public double Fiyat100 { get; set; }
        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        [ValidateNever]
        public Kategori Kategori { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
