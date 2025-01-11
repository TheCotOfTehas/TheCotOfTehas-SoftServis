using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis
{
    internal interface IHuman
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
    }
}
