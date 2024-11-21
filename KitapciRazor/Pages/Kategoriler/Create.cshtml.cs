using KitapciRazor.Data;
using KitapciRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KitapciRazor.Pages.Kategoriler
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public Kategori Kategori { get; set; }
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _context.Kategoriler.Add(Kategori);
            _context.SaveChanges();
            TempData["success"] = "Kategori Baþarý ile Eklendi";
            return RedirectToPage("Index");
        }
    }
}
