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
            
        }
    }

    public class CalendarEventConfiguration : IEntityTypeConfiguration<CalendarEvent>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CalendarEvent> builder)
        {

        }
    }

    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Room> builder)
        {

        }
    }

    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Exercise> builder)
        {
            
        }
    }
}
