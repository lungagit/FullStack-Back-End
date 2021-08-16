using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data
{
    public class FullStackDbContext: DbContext
    {
        public FullStackDbContext()
        {
        }

        public FullStackDbContext(DbContextOptions<FullStackDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source = (localDb)\\MSSQLLocalDB; Initial Catalog = FullStack");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with initial Provinces and Cities
            modelBuilder.Entity<Province>().HasData(
                new Province()
                {
                    Id = 1,
                    Name = "Gauteng"
                },
                new Province()
                {
                    Id = 2,
                    Name = "Free State"
                },
                new Province()
                {
                    Id = 3,
                    Name = "Mpumalanga"
                },
                new Province()
                {
                    Id = 4,
                    Name = "KwaZulu Natal"
                },
                new Province()
                {
                    Id = 5,
                    Name = "Western Cape"
                }
            );
            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "Johannesburg",
                    ProvinceId = 1
                },
                new City()
                {
                    Id = 2,
                    Name = "Pretoria",
                    ProvinceId = 1
                },
                new City()
                {
                    Id = 3,
                    Name = "Bloemfontein",
                    ProvinceId = 2
                },
                new City()
                {
                    Id = 4,
                    Name = "Welkom",
                    ProvinceId = 2
                },
                new City()
                {
                    Id = 5,
                    Name = "Nelspruit",
                    ProvinceId = 3
                },
                new City()
                {
                    Id = 6,
                    Name = "White River",
                    ProvinceId = 3
                },
                new City()
                {
                    Id = 7,
                    Name = "Pietermaritzburg",
                    ProvinceId = 4
                },
                new City()
                {
                    Id = 8,
                    Name = "Durban",
                    ProvinceId = 4
                },
                new City()
                {
                    Id = 9,
                    Name = "Stellenbosch",
                    ProvinceId = 5
                },
                new City()
                {
                    Id = 10,
                    Name = "Cape Town",
                    ProvinceId = 5
                }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
