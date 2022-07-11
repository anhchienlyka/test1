using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRock.Data;
using WebRock.Models;

namespace WebRock.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Categoris;
            return View(objList);
        }

        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Categoris.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }


        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoris.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }


            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Categoris.Update(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }



        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var obj =  _db.Categoris.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categoris.Remove(obj);
            _db.SaveChanges();
            TempData[SD.Success] = "User delete successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
