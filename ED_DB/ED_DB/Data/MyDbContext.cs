using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_DB.Data
{
    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

            var model = modelBuilder.Build(Database.Connection);
            ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
            _ = sqlGenerator.Generate(model.StoreModel);
            
            /*
            modelBuilder.Entity<Tables.Placement>()
                .HasRequired<Tables.Room>(o => o.room)
                .WithMany(p => p.placements)
                .HasForeignKey(o => o.UUID_Room);
            */

            /*
            modelBuilder.Entity<Tables.Placement>()
                .HasRequired(r => r.position)
                .WithRequiredPrincipal(r => r.placement);

            modelBuilder.Entity<Tables.Placement>()
                .HasRequired(r => r.rotation)
                .WithRequiredPrincipal(r => r.placement);

            modelBuilder.Entity<Tables.Room>()
                .HasMany(p => p.placements)
                .WithRequired(p => p.room)
                .HasForeignKey(s => s.UUID_Room);

            modelBuilder.Entity<Tables.Model>()
                .HasMany(p => p.placements)
                .WithRequired(p => p.model)
                .HasForeignKey(s => s.UUID_Model);
            */
        }

        public DbSet<Tables.Room> Room{ get; set; }
        public DbSet<Tables.Model> Objects{ get; set; }
        public DbSet<Tables.Position> Positions{ get; set; }
        public DbSet<Tables.Placement> Placements{ get; set; }
        public DbSet<Tables.Rotation> Rotations{ get; set; }
    }
}
