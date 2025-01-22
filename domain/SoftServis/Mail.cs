using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis
{
    public class Mail
    {
        public int Id {  get; set; }
        public Employee EmployeeName { get; set; }
        public string MailName { get; set; }
        public string Name { get; set; }

        public Mail()
        {
            EmployeeName = new Employee();
            MailName = "Тут ПО Умолчанию";
            Name = "Дефолтный Парень";
        }
    }
}
