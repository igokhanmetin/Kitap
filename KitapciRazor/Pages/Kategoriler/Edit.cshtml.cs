using KitapciRazor.Data;
using KitapciRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KitapciRazor.Pages.Kategoriler
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Kategori Kategori { get; set; }
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0) 
            {
                Kategori =_context.Kategoriler.Find(id);
            }
        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                _context.Kategoriler.Update(Kategori);
                _context.SaveChanges();
                TempData["success"] = "Kategori Baþarý ile Güncellenmiþtir.";
                return RedirectToPage("Index");

            }
            return Page();
            
        }
    }
}
