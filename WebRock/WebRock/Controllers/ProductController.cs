using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebRock.Data;
using WebRock.Models;
using WebRock.Models.ViewModels;

namespace WebRock.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public object ProductVm { get; private set; }

        public IActionResult Index()
        {
            //IEnumerable<Product> objList = _db.Product;

            //foreach(var obj in objList)
            //{
            //    obj.Category = _db.Categoris.FirstOrDefault(u => u.Id == obj.CategoryId);
            //    obj.Types = _db.Types.FirstOrDefault(u => u.Id == obj.TypeId);
            //}

            IEnumerable<Product> listEagerLoading = _db.Product.Include(u => u.Category).Include(u => u.Types);
            return View(listEagerLoading);
        }

        public IActionResult Upsert(int Id)
        {
            //IEnumerable<SelectListItem> CategoryDropDown = _db.Categoris.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            //ViewBag.CategoryDropDown = CategoryDropDown;



            //Product product = new Product();

            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategorySelectList = _db.Categoris.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                TypeSelectList = _db.Types.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if(Id == 0)
            {
                //this is for create
                return View(productVM);
            }
            else
            {
                productVM.Product = _db.Product.Find(Id);
                if(productVM.Product == null)
                {
                    return NotFound();
                }
                return View(productVM);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productVm)
        {
            if(ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                if(productVm.Product.Id == 0)
                {
                    //Create
                    string upload = webRootPath + WC.ImagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using(var fileStream = new FileStream(Path.Combine(upload, fileName+extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    productVm.Product.Image = fileName + extension;
                    _db.Product.Add(productVm.Product);

                }
                else
                {
                    //update
                    var objFromDb = _db.Product.AsNoTracking().FirstOrDefault(u => u.Id == productVm.Product.Id);



                    if(files.Count > 0)
                    {
                        string upload = webRootPath + WC.ImagePath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        var oldFile = Path.Combine(upload, objFromDb.Image);
                        if(System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        productVm.Product.Image = fileName + extension;
                    }
                    else
                    {
                        productVm.Product.Image = objFromDb.Image;
                    }
                    _db.Product.Update(productVm.Product);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Delete(int? id)
        //{
        //    if(id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product product = _db.Product.Include(u => u.Category).FirstOrDefault(u => u.Id == id);
        //    product.Category = _db.Categoris.Find(product.CategoryId);
        //    var obj = _db.Categoris.Find(id);
        //    if(obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}

        public IActionResult DeletePost(int? id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var obj = _db.Product.FirstOrDefault(u => u.Id == id);
            _db.Product.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));



        }

    }
}
