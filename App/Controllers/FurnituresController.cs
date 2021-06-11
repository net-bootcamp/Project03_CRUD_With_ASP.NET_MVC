using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class FurnituresController : Controller
    {
        private readonly AppDbcontext _db;
        public FurnituresController(AppDbcontext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Furnitures = _db.furnitures.ToList();
            ViewData["Furniture"] = Furnitures;
            return View();
        }
        public IActionResult Details(int? id)
        {
            var Furnitur = _db.furnitures.ToList().Find(Furnitur => Furnitur.Id == id);
            if (id == null || Furnitur == null)
            {
                return View("NotFound");
            }
            ViewData["Furnitur"] = Furnitur;
            return View(Furnitur);

        }

        public IActionResult Carpet()
        {
            List<Furniture> Furnitures = new List<Furniture>()
            {
                new Furniture {Id = 5 , Name="LORENA CANALS" ,Price = 1000 , Image = "https://www.amara.com/static/uploads/images-2/products/huge/173249/woolable-lakota-washable-rug-140x200cm-day-443275.jpg"},
                 new Furniture {Id = 6 , Name="ABYSS & HABIDECOR" ,Price = 1200 , Image = "https://www.amara.com/static/uploads/images-2/products/huge/153184/paros-bath-mat-800-305496.jpg"},
            };


            ViewData["Furniture"] = Furnitures;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create([Bind("Id", "Name", "Price", "Image")] Furniture F)
        {
            if (ModelState.IsValid) //check the state of model
            {
                _db.furnitures.Add(F);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(F);
        }
    
        public IActionResult Edit(int? id)
        {
            var F = _db.furnitures.ToList().Find(p => p.Id == id);
            if (id == null || F == null)
            {
                return View("_NotFound");
            }
            ViewData["Furnitur"] = F;
            return View();
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Price", "Image")] Furniture Fur)
        {
           
            _db.furnitures.Update(Fur);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var F = _db.furnitures.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || F == null)
            {
                return View("_NotFound");
            }
            _db.furnitures.Remove(F);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}