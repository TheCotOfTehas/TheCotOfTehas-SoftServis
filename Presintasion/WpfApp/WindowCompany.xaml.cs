using SoftServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для WindowCompany.xaml
    /// </summary>
    public partial class WindowCompany : Window
    {
        public WindowCompany(Company company)
        {
            InitializeComponent();
            FullName.Text = company.LongName;
            ShortName.Text = company.ShortName;
            Mails.Text = company.Mailes.First().MailName;
            INN.Text =  company.Id.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = HistoriBox.Text;
            HistoriBlock.Text += text;
        }
    }
}
