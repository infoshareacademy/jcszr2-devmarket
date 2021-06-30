using GymManagerWebApp.Models;
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
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=GymManager;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
