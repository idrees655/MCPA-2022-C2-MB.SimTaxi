using MB.SimTaxi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MB.SimTaxi.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                    .HasIndex(car => car.PlateNumber)
                    .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}