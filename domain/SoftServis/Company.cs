using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis
{
    public class Company
    {
        public int Id { get; set; }
        public long INN{ get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public Address AddressCompany { get; set; }
        public List<Telephone> Telephones { get; set; }
        public List<Mail> Mails { get; set; }
        public List<HistoryCompany> Histories { get; set; }
        public List<Product> Products { get; set; }
        public Company()
        {
            LongName = string.Empty;
            ShortName = string.Empty;
            Description = string.Empty;
            AddressCompany = new Address();
            Telephones = new List<Telephone>();
            Mails = new List<Mail>();
            INN = 0;
            Histories = new List<HistoryCompany>();
            Products = new List<Product>();
        }
    }
}
