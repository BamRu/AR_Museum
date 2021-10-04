using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_DB.Data
{
    public class MyDbContextInitializer : SqliteDropCreateDatabaseAlways<MyDbContext>
    {
        public MyDbContextInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder) { }

        protected override void Seed(MyDbContext context)
        {
        }
    }
}
