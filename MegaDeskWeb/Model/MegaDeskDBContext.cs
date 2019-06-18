using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Model
{
    public class MegaDeskDBContext : DbContext
    {
        public MegaDeskDBContext(DbContextOptions options) 
            : base(options)
        { }
        public DbSet<Desk> Desk { get; set; }
        public DbSet<DeskQuote> DeskQuote { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Rush> Rush { get; set; }
    }
}
