using App.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbcontext _db;
        public CategoriesController(AppDbcontext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Categories = _db.Categories.ToList();
            ViewData["Categories"] = Categories;
            return View();
        }

        public IActionResult Details(int id)
        {
            var a = _db.Categories.ToList().Find(a => a.Id == id);
            ViewData["Categories"] = a;
            return View();
        }

    }
}
