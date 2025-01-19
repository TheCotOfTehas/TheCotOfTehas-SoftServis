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
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public Address AddresCompany { get; set; }
        public List<Telephone> Telephones { get; set; }
        public List<Mail> Mailes { get; set; }
    }
}
