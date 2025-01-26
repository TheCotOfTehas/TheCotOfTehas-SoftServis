using SoftServis;

namespace WpfApp
{
    internal class WorkClass
    {
        internal static List<Company> GetContentBD()
        {
            List<Company> сompanies =
            [
                new Company()
                {
                    LongName = "имяДлинное1",
                    ShortName = "имяКороткое1",
                    Description = "Описание1",
                    AddresCompany = new Address(),
                    Telephones = new List<Telephone>(),
                    Mailes = new List<Mail>(){ new Mail() {MailName = "Mail1@mail.ru" } }
                },
                new Company()
                {
                    LongName = "имяДлинное2",
                    ShortName = "имяКороткое2",
                    Description = "Описание2",
                    AddresCompany = new Address(),
                    Telephones = new List<Telephone>(),
                    Mailes = new List<Mail>(){ new Mail() {MailName = "Mail2@mail.ru" } }
                },
                new Company()
                {
                    LongName = "имяДлинное3",
                    ShortName = "имяКороткое3",
                    Description = "Описание3",
                    AddresCompany = new Address(),
                    Telephones = new List<Telephone>(),
                    Mailes = new List<Mail>(){ new Mail() {MailName = "Mail3@mail.ru" } }
                }
            ];

            return сompanies;
        }
    }
}