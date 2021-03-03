using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreProgect_Ali.Models;

namespace DotNetCoreProgect_Ali.Interfaces
{
    public interface ITouristRepository
    {
        Tourist GetTourist(int id);

        IEnumerable<Tourist> GetAll();

        Tourist Add(Tourist tourist);
        Tourist Update(Tourist tourist);
        Tourist Delete(int id);
    }
}
