using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis.Memory
{
    public class DataServes
    {
        ApplicationContext DataBase { get; set; }

        public DataServes()
        {
            DataBase = new ApplicationContext();
        }

        public IEnumerable<Mail> GetAllMailCompany(int id)
        {
            var currentCompany = DataBase.Companies
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return currentCompany.Mails;
        }

        public IEnumerable<Mail> GetAllMail()
        {
            var ListMails = DataBase.Companies.Select(x => x.Mails);
            foreach (var mails in ListMails)
                foreach (var mail in mails)
                   yield return mail;
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
