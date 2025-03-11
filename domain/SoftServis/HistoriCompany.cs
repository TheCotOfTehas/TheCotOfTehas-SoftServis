using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis
{
    public class HistoryCompany
    {
        public int Id {  get; set; }
        public string Message { get; set; }
        public DateTime DateMessage { get; set; }

        public HistoryCompany()
        {
            DateMessage = DateTime.Now;
        }
        public HistoryCompany(string message) : this()
        {
            Message = message;
        }
    }
}
