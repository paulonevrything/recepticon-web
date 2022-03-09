using Microsoft.EntityFrameworkCore;
using Recepticon.Domain.Guest;
using Recepticon.Domain.Models;
using Recepticon.Domain.Rooms;
using Recepticon.Domain.RoomTypes;
using Recepticon.Domain.Users;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Recepticon.Persistence
{
    public class RecepticonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public RecepticonDbContext(DbContextOptions<RecepticonDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
                (new User { Id = 1, FirstName = "Jane", LastName = "Doe", Password = BCryptNet.HashPassword("P1ssw@rd"), Role = Role.ADMIN, IsDeleted = false, Username = "jane-doe" },
                new User { Id = 2, FirstName = "John", LastName = "Doe", Password = BCryptNet.HashPassword("P155w@rd"), Role = Role.RECEPTIONIST, IsDeleted = false, Username = "john-doe" });

            modelBuilder.Entity<Room>().HasData
                (new Room { Id = 1, RoomNumber = "200", RoomTypeId = 1, RoomStatus = RoomStatus.VACANT },
                new Room { Id = 2, RoomNumber = "201", RoomTypeId = 1, RoomStatus = RoomStatus.VACANT },
                new Room { Id = 3, RoomNumber = "202", RoomTypeId = 1, RoomStatus = RoomStatus.OCCUPIED },
                new Room { Id = 4, RoomNumber = "210", RoomTypeId = 2, RoomStatus = RoomStatus.VACANT },
                new Room { Id = 5, RoomNumber = "211", RoomTypeId = 1, RoomStatus = RoomStatus.VACANT },
                new Room { Id = 6, RoomNumber = "220", RoomTypeId = 3, RoomStatus = RoomStatus.VACANT },
                new Room { Id = 7, RoomNumber = "221", RoomTypeId = 3, RoomStatus = RoomStatus.VACANT });

            modelBuilder.Entity<RoomType>().HasData
                (new RoomType { Id = 1, RoomTypeName = "Executive", IsDeleted = false, Price = 45000.00 },
                new RoomType { Id = 2, RoomTypeName = "VIP", IsDeleted = false, Price = 30000.00 },
                new RoomType { Id = 3, RoomTypeName = "Executive VIP", IsDeleted = false, Price = 60000.00 });
                    
        
        }
    }
}
