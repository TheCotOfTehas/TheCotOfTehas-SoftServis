using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class MyMainWindow : ViewModel
    {
        private string f_Text; 

        public string Text
        {
            get => f_Text;
            set => Set(ref f_Text, value);
        }
    }
}
