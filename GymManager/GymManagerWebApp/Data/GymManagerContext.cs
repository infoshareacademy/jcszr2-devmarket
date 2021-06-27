using GymManagerWebApp.Models;
using GymManagerWebApp.Services.Exercises;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Data
{
    public class GymManagerContext : IdentityDbContext<User>
    {
        public GymManagerContext(DbContextOptions<GymManagerContext> options)
            : base(options)
        {
        }

        public GymManagerContext()
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Carnet> PurchasedCarnets { get; set; }
        public DbSet<Exercise> ListOfExercises{ get; set; }
        public DbSet<Coach> Coaches{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FUAP2NU\\SQLEXPRESS;Database=GymManager;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
