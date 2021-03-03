using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreProgect_Ali.Data;
using DotNetCoreProgect_Ali.Interfaces;
using DotNetCoreProgect_Ali.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreProgect_Ali.Controllers
{
    public class HotelController : Controller
    {
        private IHotelRepository db;
        private ITouristRepository it;
        private ApplicationDbContext _context;

        public HotelController(IHotelRepository db, ITouristRepository it, ApplicationDbContext _context)
        {
            this.db = db;
            this.it = it;
            this._context = _context;
        }
        public IActionResult Index()
        {
            var applicationDbContext = _context.Tourists.ToList();
            return View(db.GetAll());
        }



        // GET:Create
        public IActionResult Create()
        {
            ViewBag.TouristId = it.GetAll();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel hotel)
        {
            ViewBag.TouristId = it.GetAll();
            db.Add(hotel);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var applicationDbContext = _context.Tourists.ToList();
            ViewBag.TouristId = it.GetAll();
            return View(db.GetHotel(id));
        }

        [HttpPost]
        public IActionResult Edit(Hotel hotel)
        {
            ViewBag.TouristId = it.GetAll();
            db.Update(hotel);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(db.GetHotel(id));
        }
    }
}
