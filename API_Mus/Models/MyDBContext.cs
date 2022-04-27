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
                .HasOne(p => p.Position)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Placement>()
                .HasOne(p => p.Rotation)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Placement>()
                .HasOne(p => p.Room)
                .WithMany(r => r.Placement)
                .OnDelete(DeleteBehavior.Cascade);


     
            modelBuilder.Entity<Rotation>()
                .HasKey(r => r.UUID);

            modelBuilder.Entity<Position>()
                .HasKey(r => r.UUID);

        }
        public DbSet<Placement> Placements { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rotation> Rotations { get; set; }

    }
}
