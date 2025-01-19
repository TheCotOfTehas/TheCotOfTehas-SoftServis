using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis
{
    public class Address
    {
        public int Id { get; set; }
        public string address { get; set; } = "ПоУмолчанию";
    }
}
