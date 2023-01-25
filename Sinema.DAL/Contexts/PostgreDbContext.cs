using Microsoft.EntityFrameworkCore;
using Sinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinema.DAL.Contexts
{
    public class PostgreDbContext:DbContext
    {

        public DbSet<Film> Filmler{ get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=127.0.0.1;Database=Sinema;user Id=postgres;password=123");
        }
    }
}
