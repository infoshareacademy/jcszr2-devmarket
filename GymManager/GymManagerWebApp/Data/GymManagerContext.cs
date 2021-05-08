using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Data
{
    public class GymManagerContext : IdentityDbContext 
    {
        public GymManagerContext(DbContextOptions<GymManagerContext> options)
            : base(options)
        {
        }

        public GymManagerContext()
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Carnet> PurchasedCarnets { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Server=localhost;Database=GymManager;Integrated Security=true;");
        //    base.OnConfiguring(optionsBuilder);
            
           
        //}
    }
}
