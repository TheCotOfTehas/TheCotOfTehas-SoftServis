using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis.Memory
{
    public class DataServis
    {
        DataContext context;

        public DataServis()
        {
            context = new DataContext();
        }
    }
}
