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
        public Address AddresCompany { get; set; }
        public List<Telephone> Telephones { get; set; }
        public List<Mail> Mailes { get; set; }
        public List<HistoryCompany> Historys { get; set; }
        public Company()
        {
            LongName = string.Empty;
            ShortName = string.Empty;
            Description = string.Empty;
            AddresCompany = new Address();
            Telephones = new List<Telephone>();
            Mailes = new List<Mail>();
            INN = 0;
            Historys = new List<HistoryCompany>() 
            { 
                new HistoryCompany(){Message = "Это начало истории работы с компанией"},
            };
        }
    }
}
