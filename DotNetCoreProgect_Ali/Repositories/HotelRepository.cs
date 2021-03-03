using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotNetCoreProgect_Ali.Data;
using DotNetCoreProgect_Ali.Interfaces;
using DotNetCoreProgect_Ali.Models;

namespace DotNetCoreProgect_Ali.Repositories
{
    public class HotelRepository: IHotelRepository
    {
        private readonly ApplicationDbContext db;
        public HotelRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Hotel Add(Hotel hotel)
        {
            db.Hotels.Add(hotel);
            db.SaveChanges();

            return hotel;
        }

        public Hotel Delete(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            if (hotel != null)
            {
                db.Hotels.Remove(hotel);
                db.SaveChanges();
            }
            return hotel;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return db.Hotels;
        }

        public Hotel GetHotel(int id)
        {
            return db.Hotels.Where(x => x.HotelID == id).SingleOrDefault();
        }

        public Hotel Update(Hotel hotel)
        {
            db.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return hotel;
        }
    }
}
