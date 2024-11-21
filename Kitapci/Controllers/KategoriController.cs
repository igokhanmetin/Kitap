
using Kitapci.DataAcsess.Data;
using Kitapci.DataAcsess.Repository.IRepository;
using Kitapci.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kitapci.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IKategoriRepository _kategorirepo;

        public KategoriController(IKategoriRepository context)
        {
            _kategorirepo = context;
        }

        public IActionResult Index()
        {
            List<Kategori> kategoriListesi = _kategorirepo.GetAll().ToList();
            return View(kategoriListesi);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kategori obj) 
        {
            if (obj.Ad == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("ad", "isim ile kategori numarası aynı olamaz");
            }

            if (ModelState.IsValid)
            {
                _kategorirepo.Add(obj);
                _kategorirepo.Save();
                TempData["success"] = "Kategori Başarı ile Eklenmiştir.";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kategori? _kategoriFromContext = _kategorirepo.Get(u=>u.Id==id);
            if (_kategoriFromContext == null)
            {
                return NotFound();
            }
            return View(_kategoriFromContext);
        }

        [HttpPost]
        public IActionResult Edit(Kategori obj)
        {
            
            if (ModelState.IsValid)
            {
                _kategorirepo.Update(obj);
                _kategorirepo.Save();
                TempData["success"] = "Kategori Başarı ile Güncellenmiştir.";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kategori? _kategoriFromContext = _kategorirepo.Get(u => u.Id == id);
            if (_kategoriFromContext == null)
            {
                return NotFound();
            }
            return View(_kategoriFromContext);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Kategori? obj = _kategorirepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _kategorirepo.Remove(obj);
            _kategorirepo.Save();
            TempData["success"] = "Kategori Başarı ile Silinmiştir.";
            return RedirectToAction("Index");
        }

           
        
    }
}
