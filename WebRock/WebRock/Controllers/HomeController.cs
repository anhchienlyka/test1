using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebRock.Data;
using WebRock.Models;
using WebRock.Models.ViewModels;
using WebRock.Utility;

namespace WebRock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVm homeVM = new HomeVm()
            {
                Products = _db.Product.Include(u => u.Category).Include(u => u.Types),
                Categories = _db.Categoris,
                ExistsInCart = false
            };
            return View(homeVM);
        }

        public IActionResult Details(int id)
        {
            var Product = _db.Product.Include(u => u.Category).Include(u => u.Types)
                .Where(u => u.Id == id).FirstOrDefault();
            
            return View(Product);
        }

       
        public IActionResult DetailsPost(int id)
        {
            List<ShoppingCart> ShoppingCartList = new List<ShoppingCart>();
            if(HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                ShoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);

            }
            var product = _db.Product.FirstOrDefault(u => u.Id == id);
            
            ShoppingCartList.Add(new ShoppingCart { product = product});
            HttpContext.Session.Set(WC.SessionCart, ShoppingCartList);
            return RedirectToAction(nameof(Index));
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
