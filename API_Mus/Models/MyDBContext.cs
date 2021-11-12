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

            modelBuilder.Entity<Placement>()
                .HasKey(r => r.UUID);

            modelBuilder.Entity<Placement>()
               .HasOne(p => p.Model)
               .WithMany(m => m.Placement);

            modelBuilder.Entity<Placement>()
                .HasOne(p => p.Position)
                .WithOne();

            modelBuilder.Entity<Placement>()
                .HasOne(p => p.Room)
                .WithMany(r => r.Placement);

            modelBuilder.Entity<Placement>()
                .HasOne(p => p.Rotation)
                .WithOne();

            modelBuilder.Entity<Model>()
                .HasKey(r => r.UUID);
     
            modelBuilder.Entity<Rotation>()
                .HasKey(r => r.UUID);

            modelBuilder.Entity<Position>()
                .HasKey(r => r.UUID);

        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Placement> Placements { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rotation> Rotations { get; set; }

    }
}
