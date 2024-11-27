using Car_Rental_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Car_Rental_Api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        //This is to generate guid for car and user model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<User>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");
        }

    }
}
