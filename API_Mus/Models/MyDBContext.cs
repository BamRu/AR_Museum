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
            

            modelBuilder.Entity<Placement>()
               .HasOne(p => p.Model)
               .WithMany(m => m.Placement)
               .HasForeignKey(p => p.UUID_Model);

            modelBuilder.Entity<Placement>()
                .HasOne(p => p.Position)
                .WithOne();

            modelBuilder.Entity<Placement>()
                .HasOne(p => p.Room)
                .WithMany(r => r.Placement)
                .HasForeignKey(p => p.UUID_Room);

            modelBuilder.Entity<Placement>()
                .HasOne(p => p.Rotation)
                .WithOne();


            modelBuilder.Entity<Room>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Placement>()
                .HasKey(r =>  new { r.UUID_Room, r.UUID_Model});

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
