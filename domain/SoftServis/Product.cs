using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis
{
    public class Product
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public DateTime DatePurchase { get; set; }
        public DateTime LicenseValidity { get; set; }
    }
}
