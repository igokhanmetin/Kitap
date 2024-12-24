using Kitapci.DataAcsess.Repository.IRepository;
using Kitapci.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kitapci.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Kitap> kitapListesi = _unitOfWork.Kitap.GetAll(includeProperties: "Kategori");
            return View(kitapListesi);
        }
        
        public IActionResult Details(int kitapId)
        {
            Kitap kitap = _unitOfWork.Kitap.Get(u=>u.Id== kitapId, includeProperties: "Kategori");
            return View(kitap);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
