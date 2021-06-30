using GymManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagerWebApp.Data
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Room> builder)
        {
            builder.HasMany(x => x.Exercises).WithMany(x => x.Rooms);
        }
    }

}
