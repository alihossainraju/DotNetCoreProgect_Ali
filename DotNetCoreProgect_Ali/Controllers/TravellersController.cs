using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreProgect_Ali.Data;
using DotNetCoreProgect_Ali.Models;

namespace Demo2.Controllers
{
    public class TravellersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public readonly IHostingEnvironment _hostingEnvironment;

        public TravellersController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.TravellerID = new SelectList(_context.Travellers, "ID", "Name");
            return View(await _context.Travellers.ToListAsync());
        }
        public ActionResult TravellerOrder(long? id)
        {
            if (id == null)
            {
                NotFound();
            }

            ViewData["id"] = id;
            List<Order> orders = _context.Orders.Where(e => e.TravellerID == id).ToList();

            if (orders == null)
            {
                NotFound();
            }

            return PartialView("TravellerOrder", orders);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order, Traveller traveller, IFormFile[] Image)
        {
            try
            {

                if (Image != null)
                {
                    if (traveller.Orders.Count == Image.Count())
                    {
                        for (int i = 0; i < traveller.Orders.Count; i++)
                        {

                            string picture = System.IO.Path.GetFileName(Image[i].FileName);
                            var file = picture;
                            var uploadFile = Path.Combine(_hostingEnvironment.WebRootPath, "images", picture);

                            using (MemoryStream ms = new MemoryStream())
                            {
                                Image[i].CopyTo(ms);
                                traveller.Orders[i].Image = ms.GetBuffer();
                            }
                        }
                    }
                    _context.Travellers.Add(traveller);
                    _context.SaveChanges();
                    TempData["id"] = traveller.ID;
                    return RedirectToAction("Index");
                }

                return View(traveller);
            }
            catch (Exception)
            {
                return View(traveller);
            }
        }


        public IActionResult Delete(long id)
        {
            Traveller traveller = _context.Travellers.Find(id);
            if (traveller != null)
            {
                _context.Travellers.Remove(traveller);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(long id)
        {
            Order order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
