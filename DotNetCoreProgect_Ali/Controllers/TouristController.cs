using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreProgect_Ali.Interfaces;
using DotNetCoreProgect_Ali.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreProgect_Ali.Controllers
{
    public class TouristController : Controller
    {
        private ITouristRepository db;

        public TouristController(ITouristRepository db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.GetAll());
        }



        // GET:Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tourist tourist)
        {

            db.Add(tourist);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(db.GetTourist(id));
        }

        [HttpPost]
        public IActionResult Edit(Tourist tourist)
        {
            db.Update(tourist);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(db.GetTourist(id));
        }
    }
}
