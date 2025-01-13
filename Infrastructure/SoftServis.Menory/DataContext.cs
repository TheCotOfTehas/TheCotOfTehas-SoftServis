using Microsoft.EntityFrameworkCore;
using SoftServis.Menory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis.Memory
{
    public class DataContext : DbContext
    {
        public DbSet<Company> CompanyDB { get; set; } = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
