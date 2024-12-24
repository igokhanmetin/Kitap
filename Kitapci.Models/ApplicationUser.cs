using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapci.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Ad { get; set; }

        public string? Sokak { get; set; }
        public string? Sehir { get; set; }
        public string? Ilce { get; set; }
        public string? PostaKodu { get; set; }
    }
}
