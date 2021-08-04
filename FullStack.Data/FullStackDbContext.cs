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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localDb)\\MSSQLLocalDB; Initial Catalog = FullStack");
        }

    }
}
