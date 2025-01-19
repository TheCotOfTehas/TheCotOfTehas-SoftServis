using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis.Memory
{
    public class DataServis
    {
        ApplicationContext context;

        public DataServis()
        {
            context = new ApplicationContext();
        }

        public IEnumerable<Mail> GetAllMailCompany(string name)
        {
            if (name is null) return null;

            var currentCompany = context.companies
                .Where(x => x.LongName == name)
                .FirstOrDefault();

            if (currentCompany is null) return null;

            return currentCompany.Mailes;
        }
    }
}
