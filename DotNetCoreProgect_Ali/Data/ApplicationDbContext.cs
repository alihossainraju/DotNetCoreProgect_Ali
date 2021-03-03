using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetCoreProgect_Ali.Models;

namespace DotNetCoreProgect_Ali.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
    }
}
