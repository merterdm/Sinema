using Microsoft.EntityFrameworkCore;
using Sinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinema.DAL.Contexts
{
    public class SqlDbContext:DbContext
    {

        public DbSet<Film> Filmler{ get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;Database=Sinema;Intergrated_Security=true");
        }
    }
}
