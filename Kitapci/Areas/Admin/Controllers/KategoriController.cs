using Kitapci.DataAcsess.Repository.IRepository;
using Kitapci.Models;
using Kitapci.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitapci.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class KategoriController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public KategoriController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            List<Kategori> kategoriListesi = _unitOfWork.Kategori.GetAll().ToList();
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
                _unitOfWork.Kategori.Add(obj);
                _unitOfWork.Save();
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
            Kategori? _kategoriFromContext = _unitOfWork.Kategori.Get(u => u.Id == id);
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
                _unitOfWork.Kategori.Update(obj);
                _unitOfWork.Save();
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
            Kategori? _kategoriFromContext = _unitOfWork.Kategori.Get(u => u.Id == id);
            if (_kategoriFromContext == null)
            {
                return NotFound();
            }
            return View(_kategoriFromContext);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Kategori? obj = _unitOfWork.Kategori.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Kategori.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Kategori Başarı ile Silinmiştir.";
            return RedirectToAction("Index");
        }



    }
}
