using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CatalogAPI.DataBase
{

    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CatalogDb");
        }
        //public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Models.Catalog> Items { get; set; }
    }
}
