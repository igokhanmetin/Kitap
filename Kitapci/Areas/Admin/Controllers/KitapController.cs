using Kitapci.DataAcsess.Repository.IRepository;
using Kitapci.Models;
using Kitapci.Models.ViewModels;
using Kitapci.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Kitapci.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class KitapController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public KitapController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Kitap> KitapListesi = _unitOfWork.Kitap.GetAll(includeProperties:"Kategori").ToList();
            return View(KitapListesi);
        }
        public IActionResult Upsert(int? id)
        {
            //ViewBag.kategoriListesi = kategoriListesi;
            KitapVM kitapVM = new()
            {
                kategoriListesi = _unitOfWork.Kategori.GetAll().Select(u => new SelectListItem
               {
                   Text = u.Ad,
                   Value = u.Id.ToString()
               }),
                Kitap = new Kitap()
            };
            if (id == null || id == 0)
            {
                //create
                return View(kitapVM);

            }
            else
            {
                //update
                kitapVM.Kitap = _unitOfWork.Kitap.Get(u=>u.Id == id);
                return View(kitapVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(KitapVM kitapVM , IFormFile? file)
        {
            
            if (ModelState.IsValid)
            {
                string wwwwRootPath =_webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string kitapPath = Path.Combine(wwwwRootPath, @"images\kitap");

                    if(!string.IsNullOrEmpty(kitapVM.Kitap.ImageUrl))
                    {
                        //eski resmi silme
                        var oldImagePath = Path.Combine(wwwwRootPath, kitapVM.Kitap.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using(var fileStream =new FileStream(Path.Combine(kitapPath, fileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    kitapVM.Kitap.ImageUrl = @"\images\kitap\" + fileName;
                }
                if(kitapVM.Kitap.Id == 0)
                {
                    _unitOfWork.Kitap.Add(kitapVM.Kitap);

                }
                else
                {
                    _unitOfWork.Kitap.Update(kitapVM.Kitap);

                }
                _unitOfWork.Save();
                TempData["success"] = "Kitap Başarı ile Eklenmiştir.";
                return RedirectToAction("Index");
            }
            else
            {
                kitapVM.kategoriListesi = _unitOfWork.Kategori.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Ad,
                    Value = u.Id.ToString()
                });

                return View(kitapVM);
            }
        }
      
        #region API CALLS 
        [HttpGet] 
        public IActionResult GetAll() 
        { 
            List<Kitap> KitapListesi = _unitOfWork.Kitap.GetAll(includeProperties: "Kategori").ToList(); 
            return Json(new { data = KitapListesi }); }
        [HttpDelete]
        public IActionResult Delete(int? id) 
        { 
            var kitapDeleted = _unitOfWork.Kitap.Get(u=>u.Id == id); 

            if(kitapDeleted == null)
            {
                return Json(new { succes = false, message = "Bu kitap daha önce silinmiştir" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, kitapDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Kitap.Remove(kitapDeleted);
            _unitOfWork.Save();

            return Json(new { succes = true, message = "Kitap başarı ile silindi" });
        }
        #endregion


    }
}
