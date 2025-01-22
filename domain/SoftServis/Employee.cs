using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis
{
    public class Employee : Human
    {
        public int Id { get; set; }
        public int IdentificationNumber {  get; set; }
        public Address ResidentialAddress { get; set; }
        public string PositionAtWork { get; set; }

        public Employee() 
        {
            IdentificationNumber = 0;
            ResidentialAddress = new Address();
            PositionAtWork = string.Empty;
        }
    }
}
