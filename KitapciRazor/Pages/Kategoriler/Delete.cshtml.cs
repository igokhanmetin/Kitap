using KitapciRazor.Data;
using KitapciRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KitapciRazor.Pages.Kategoriler
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Kategori Kategori { get; set; }
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Kategori = _context.Kategoriler.Find(id);
            }
        }
        public IActionResult OnPost()
        {
                Kategori? obj = _context.Kategoriler.Find(Kategori.Id);
                if (obj == null)
                {
                    return NotFound();
                }
                _context.Kategoriler.Remove(obj);
                _context.SaveChanges();
                TempData["success"] = "Kategori Baþarý ile Silindi";
                 return RedirectToPage("Index");
        }
    }
}
