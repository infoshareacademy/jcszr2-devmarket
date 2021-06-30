using GymManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Data
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Coach> builder)
        {
            builder.HasMany(x => x.Exercises).WithMany(x => x.Coaches);
            builder.HasMany(x => x.CalendarEvents).WithOne(x => x.Coach);
        }
    }

}
