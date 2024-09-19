using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ПР43_Осокин.Context
{
    public class CategorysContext : DbContext
    {
        public DbSet<Models.Categorys> Categorys { get; set; }
        public CategorysContext()
        {
            Database.EnsureCreated();
            Categorys.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Classes.Connection.connection, Classes.Connection.version);
    }
}
