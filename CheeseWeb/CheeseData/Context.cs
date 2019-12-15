using CheeseModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace CheeseData
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> optionsBuilder)
        : base(optionsBuilder)
        {
        }

        public virtual DbSet<Cheese> Cheese { get; set; }
        public virtual DbSet<CheesePicture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
