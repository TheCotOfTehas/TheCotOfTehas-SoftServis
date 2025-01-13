using System.ComponentModel.DataAnnotations.Schema;

namespace SoftServis.Menory
{
    public class CompanyRepositore : ICompanyRepositore
    {
        private readonly List<Company> сompanies = new List<Company>();

        public Company[] GetAllCompanies(string title)
        {
            return сompanies.Where(company => company.LongName.Contains(title))
                .ToArray();
        }
    }
}
