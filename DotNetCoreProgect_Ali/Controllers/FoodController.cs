using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreProgect_Ali.Data;
using DotNetCoreProgect_Ali.Models;
using DotNetCoreProgect_Ali.ViewModels;

namespace DotNetCoreProgect_Ali.Controllers
{
    public class FoodController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApplicationDbContext db;
        private readonly IHostingEnvironment webHostEnvironment;
        public FoodController(ApplicationDbContext context, IHostingEnvironment hostEnvironment)
        {
            db = context;
            webHostEnvironment = hostEnvironment;
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await db.Foods.ToListAsync());
        //}

        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var foods = from s in db.Foods
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(s => s.FoodName.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    foods = foods.OrderByDescending(s => s.FoodName);
                    break;
                case "Date":
                    foods = foods.OrderBy(s => s.PurchasesDate);
                    break;
                case "date_desc":
                    foods = foods.OrderByDescending(s => s.PurchasesDate);
                    break;
                default:
                    foods = foods.OrderBy(s => s.FoodName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Food>.CreateAsync(foods.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await instractors.AsNoTracking().ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await db.Foods
                .FirstOrDefaultAsync(f => f.Id == id);

            var foodViewModel = new FoodViewModel()
            {
                Id = food.Id,
                FoodName = food.FoodName,
                Quality = food.Quality,
                Quantity = food.Quantity,
                PurchasesDate = food.PurchasesDate,
                PurchasesTime = food.PurchasesTime,
                Place = food.Place,
                ExistingImage = food.Image
            };

            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Food food = new Food
                {
                    FoodName = model.FoodName,
                    Quality = model.Quality,
                    Quantity = model.Quantity,
                    PurchasesDate = model.PurchasesDate,
                    PurchasesTime = model.PurchasesTime,
                    Place = model.Place,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    Image = uniqueFileName
                };

                db.Add(food);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await db.Foods.FindAsync(id);
            var foodViewModel = new FoodViewModel()
            {
                Id = food.Id,
                FoodName = food.FoodName,
                Quality = food.Quality,
                Quantity = food.Quantity,
                PurchasesDate = food.PurchasesDate,
                PurchasesTime = food.PurchasesTime,
                Place = food.Place,
                Password = food.Password,
                ConfirmPassword = food.ConfirmPassword,
                ExistingImage = food.Image
            };

            if (food == null)
            {
                return NotFound();
            }
            return View(foodViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var food = await db.Foods.FindAsync(model.Id);
                food.FoodName = model.FoodName;
                food.Quality = model.Quality;
                food.Quantity = model.Quantity;
                food.PurchasesDate = model.PurchasesDate;
                food.PurchasesTime = model.PurchasesTime;
                food.Place = model.Place;
                food.Password = model.Password;
                food.ConfirmPassword = model.ConfirmPassword;
                if (model.Image != null)    ///////
                {
                    if (model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    food.Image = ProcessUploadedFile(model);
                }
                db.Update(food);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await db.Foods
                .FirstOrDefaultAsync(m => m.Id == id);

            var foodViewModel = new FoodViewModel()
            {
                Id = food.Id,
                FoodName = food.FoodName,
                Quality = food.Quality,
                Quantity = food.Quantity,
                PurchasesDate = food.PurchasesDate,
                PurchasesTime = food.PurchasesTime,
                Place = food.Place,
                ExistingImage = food.Image
            };
            if (food == null)
            {
                return NotFound();
            }

            return View(foodViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var food = await db.Foods.FindAsync(id);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", food.Image);
            db.Foods.Remove(food);
            if (await db.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
            return db.Foods.Any(e => e.Id == id);
        }

        private string ProcessUploadedFile(FoodViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)    /////
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;    //////
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream); ////////
                }
            }

            return uniqueFileName;
        }
    }
}