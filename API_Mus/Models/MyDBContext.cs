using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API_Mus.Models
{
    public class MyDBContext : DbContext
    {
        
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasKey(r => r.Id);
                
        }

        //public DbSet<Model> Models { get; set; }
       //public DbSet<Placement> Placements { get; set; }
        public DbSet<Room> Rooms { get; set; }
        //public DbSet<Position> Positions { get; set; }
        //public DbSet<Rotation> Rotations { get; set; }

    }
}
