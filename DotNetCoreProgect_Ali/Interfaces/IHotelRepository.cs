using DotNetCoreProgect_Ali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProgect_Ali.Interfaces
{
    public interface IHotelRepository
    {
        Hotel GetHotel(int id);

        IEnumerable<Hotel> GetAll();

        Hotel Add(Hotel hotel);
        Hotel Update(Hotel hotel);
        Hotel Delete(int id);
    }
}
