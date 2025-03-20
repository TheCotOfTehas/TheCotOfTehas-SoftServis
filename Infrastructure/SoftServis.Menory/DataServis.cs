using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis.Memory
{
    public class DataServis
    {
        ApplicationContext DataBase { get; set; }

        public DataServis()
        {
            DataBase = new ApplicationContext();
        }

        public IEnumerable<Mail> GetAllMailCompany(string name)
        {
            if (name is null) return null;

            var currentCompany = DataBase.Companies
                .Where(x => x.LongName == name)
                .FirstOrDefault();

            if (currentCompany is null) return null;

            return currentCompany.Mails;
        }

        public Company GetCompany(int id)
        {
            var companyCurrent = DataBase
                .Companies
                .Include(company => company.Histories)
                .Include(company => company.Mails)
                .Include(company => company.Products)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return companyCurrent != null ? companyCurrent : new Company();
        }
    }
}
