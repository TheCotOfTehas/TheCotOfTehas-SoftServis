using System.ComponentModel.DataAnnotations.Schema;

namespace SoftServis.Menory
{
    public class CompanyRepositore : ICompanyRepositore
    {
        private readonly List<Company> Companies = new List<Company>();

        public Company[] GetAllCompanies(string title)
        {
            return Companies.Where(company => company.LongName.Contains(title))
                .ToArray();
        }
    }
}
