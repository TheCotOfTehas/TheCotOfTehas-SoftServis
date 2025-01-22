using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis
{
    public class Telephone
    {
        public int Id { get; set; }
        public Employee EmployeeName { get; set; }
        public int Numder {  get; set; }
        public string Name { get; set; }

        public Telephone() 
        { 
            EmployeeName = new Employee();
            Numder = 0;
            Name = string.Empty;
        }
    }
}
