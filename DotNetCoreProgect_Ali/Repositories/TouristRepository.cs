using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotNetCoreProgect_Ali.Data;
using DotNetCoreProgect_Ali.Interfaces;
using DotNetCoreProgect_Ali.Models;

namespace DotNetCoreProgect_Ali.Repositories
{
    public class TouristRepository: ITouristRepository
    {
        private readonly ApplicationDbContext db;
        public TouristRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Tourist Add(Tourist tourist)
        {
            db.Tourists.Add(tourist);
            db.SaveChanges();

            return tourist;
        }

        public Tourist Delete(int id)
        {
            Tourist tourist = db.Tourists.Find(id);
            if (tourist != null)
            {
                db.Tourists.Remove(tourist);
                db.SaveChanges();
            }
            return tourist;
        }

        public IEnumerable<Tourist> GetAll()
        {
            return db.Tourists;
        }

        public Tourist GetTourist(int id)
        {
            return db.Tourists.Where(x => x.TouristId == id).SingleOrDefault();
        }

        public Tourist Update(Tourist tourist)
        {
            db.Entry(tourist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return tourist;
        }
    }
}
