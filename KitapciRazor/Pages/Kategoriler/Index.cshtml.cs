using KitapciRazor.Data;
using KitapciRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KitapciRazor.Pages.Kategoriler
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Kategori> Kategorilistesi {  get; set; }
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Kategorilistesi = _context.Kategoriler.ToList();
        }
    }
}
