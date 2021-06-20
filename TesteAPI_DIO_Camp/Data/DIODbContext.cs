using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAPI_DIO_Camp.Models;

namespace TesteAPI_DIO_Camp.Data
{
    public class DIODbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString:
                @"Server=DESKTOP-OEF3FS8;Database=DIOCampDataAPI;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
    }
}
