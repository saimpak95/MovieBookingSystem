using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBooking_DomainModels
{
   public class DataContext  :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
