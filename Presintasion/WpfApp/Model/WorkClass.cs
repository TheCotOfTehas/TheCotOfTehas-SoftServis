﻿using SoftServis;

namespace WpfApp.Model
{
    internal class WorkClass
    {
        internal static List<Company> GetContentBD()
        {
            List<Company> сompanies =
            [
                new Company()
                {
                    INN= 1598756891,
                    LongName = "ООО \"Монолит\"",
                    ShortName = "Монолит",
                    Description = "компания заниммается железобетонными конструкциями",
                    AddressCompany = new Address(),
                    Telephones = new List<Telephone>(), 
                    Mails = new List<Mail>(){ new Mail() {MailName = "Mail1@mail.ru" } },
                    Products = new List<Product>(){
                        new Product(){Name ="ГРАНД-смета Флеш", DatePurchase = DateTime.Now, LicenseValidity = DateTime.Now}
                    }
                },
                new Company()
                {
                    INN = 1598756895,
                    LongName = "СЗ \"Мегаполис\"",
                    ShortName = "Мегаполис",
                    Description = "Застройщик",
                    AddressCompany = new Address(),
                    Telephones = new List<Telephone>(),
                    Mails = new List<Mail>(){ new Mail() {MailName = "Mail2@mail.ru" } }
                },
                new Company()
                {
                    INN = 1400568940,
                    LongName = "ИП Бортников",
                    ShortName = "Бортников",
                    Description = "Конкурент, ранее занимался продажами программы ГРАНД-смета в Костроме",
                    AddressCompany = new Address(),
                    Telephones = new List<Telephone>(),
                    Mails = new List<Mail>(){ new Mail() {MailName = "Mail3@mail.ru" } }
                }
            ];

            return сompanies;
        }
    }
}