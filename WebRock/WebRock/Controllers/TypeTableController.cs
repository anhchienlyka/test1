using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRock.Data;
using WebRock.Models;

namespace WebRock.Controllers
{
    public class TypeTableController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TypeTableController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<TypeTable> listType = _db.Types; 
            return View(listType);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TypeTable objType)
        {
            _db.Types.Add(objType);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            if(Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Types.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TypeTable obj)
        {
            if(ModelState.IsValid)
            {
                _db.Types.Update(obj);
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
            var obj = _db.Types.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }_db.Types.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
