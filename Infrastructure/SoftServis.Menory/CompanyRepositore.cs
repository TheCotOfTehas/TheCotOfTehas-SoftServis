namespace SoftServis.Menory
{
    public class CompanyRepositore : ICompanyRepositore
    {
        private readonly Company[] сompanies =
        [
            new Company()
            {
                Id = 1,
                LongName = "имяДлинное1",
                ShortName = "имяКороткое1",
                Description = "Описание1",
                AddresCompany = new Address(),
                Telephones = new Telephone[5],
                Mailes = new Mail[5]
            },
            new Company()
            {
                Id = 2,
                LongName = "имяДлинное2",
                ShortName = "имяКороткое2",
                Description = "Описание2",
                AddresCompany = new Address(),
                Telephones = new Telephone[5],
                Mailes = new Mail[5]
            },
            new Company()
            {
                Id = 3,
                LongName = "имяДлинное3",
                ShortName = "имяКороткое3",
                Description = "Описание3",
                AddresCompany = new Address(),
                Telephones = new Telephone[5],
                Mailes = new Mail[5]
            }
        ];
        public Company[] GetAllCompanies(string title)
        {
            return сompanies.Where(company => company.LongName.Contains(title))
                .ToArray();
        }
    }
}
