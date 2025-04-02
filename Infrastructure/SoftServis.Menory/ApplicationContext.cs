using Microsoft.EntityFrameworkCore;
using SoftServis.Menory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis.Memory
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Database=dbCompany; Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=dbCompany; Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
